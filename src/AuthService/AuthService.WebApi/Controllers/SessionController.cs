using AuthService.Application.Login;
using AuthService.Application.LogoutAll;
using AuthService.Application.TokenRefresh;
using AuthService.Domain;
using AuthService.WebApi.Models.Session;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
    [Route("[controller]")]
    public class SessionController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Аутентифицирует пользователя по логину и паролю.
        /// </summary>
        /// <remarks>
        /// При успешной авторизации устанавливаются cookies:
        /// - <c>access_token</c>
        /// - <c>refresh_token</c>
        /// 
        /// Оба токена защищены и устанавливаются как <c>HttpOnly</c>.
        /// </remarks>
        /// <param name="loginDto">Логин и пароль пользователя</param>
        /// <returns>200 OK в случае успеха; 401 Unauthorized — при ошибке авторизации</returns>
        /// <response code="200">Успешный вход. Токены записаны в cookies.</response>
        /// <response code="401">Неверный логин или пароль</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var command = _mapper.Map<LoginCommand>(loginDto);
            var tokens = await Mediator.Send(command);
            SetCookies(tokens);
            return Ok();
        }

        /// <summary>
        /// Завершает все активные сессии пользователя (везде выходит из системы).
        /// </summary>
        /// <remarks>
        /// Удаляет cookies <c>access_token</c> и <c>refresh_token</c>, а также инвалидирует все refresh-токены.
        /// </remarks>
        /// <param name="logoutAllDto">Идентификационные данные пользователя или токена</param>
        /// <returns>200 OK — пользователь вышел из всех сессий</returns>
        /// <response code="200">Все сессии завершены</response>
        /// <response code="401">Невалидный токен или пользователь не авторизован</response>
        [HttpPost("logout-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogoutAll([FromBody] LogoutAllDto logoutAllDto)
        {
            Response.Cookies.Delete("access_token");
            Response.Cookies.Delete("refresh_token");
            var command = _mapper.Map<LogoutAllCommand>(logoutAllDto);
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновляет токены авторизации по <c>refresh_token</c>, хранящемуся в cookie.
        /// </summary>
        /// <remarks>
        /// Возвращает новые access и refresh токены и обновляет их в cookies.
        ///
        /// - Если refresh токен не найден — возвращается <c>401 Unauthorized</c>
        /// - Если токен просрочен или недействителен — возвращается <c>401 Unauthorized</c>
        /// </remarks>
        /// <returns>200 OK с обновлёнными токенами в cookies</returns>
        /// <response code="200">Токены обновлены</response>
        /// <response code="401">Отсутствует refresh token или он недействителен</response>
        [HttpPost("refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RefreshToken()
        {
            if (!Request.Cookies.TryGetValue("refresh_token", out var refreshToken))
                return Unauthorized();

            var command = new RefreshTokenCommand { RefreshToken = refreshToken };
            var tokens = await Mediator.Send(command);
            SetCookies(tokens);
            return Ok();
        }

        private void SetCookies(TokensDto tokensDto)
        {
            Response.Cookies.Append("access_token", tokensDto.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = tokensDto.AccessExpiresAt
            });

            Response.Cookies.Append("refresh_token", tokensDto.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = tokensDto.RefreshExpiresAt
            });
        }
    }
}
