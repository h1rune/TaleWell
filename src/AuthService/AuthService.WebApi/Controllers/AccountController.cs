using AuthService.Application.ConfirmEmail;
using AuthService.Application.RegisterAccount;
using AuthService.WebApi.Models.Account;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
    [Route("[controller]")]
    public class AccountController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Регистрирует нового пользователя и отправляет письмо для подтверждения почты.
        /// </summary>
        /// <remarks>
        /// Возвращает уникальный идентификатор аккаунта (GUID).
        ///
        /// После регистрации на указанный email будет отправлено письмо с ссылкой на подтверждение.
        /// </remarks>
        /// <param name="registerDto">Данные для регистрации нового аккаунта</param>
        /// <returns>200 OK с ID аккаунта</returns>
        /// <response code="200">Регистрация успешна</response>
        /// <response code="400">Ошибка валидации данных</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var command = _mapper.Map<RegisterAccountCommand>(registerDto);
            var accountId = await Mediator.Send(command);
            return Ok(accountId);
        }

        /// <summary>
        /// Подтверждает адрес электронной почты пользователя.
        /// </summary>
        /// <remarks>
        /// Используется после перехода по ссылке из письма. 
        ///
        /// Требуется передать email и токен в query-параметрах:
        /// - <c>?email=user@example.com&amp;token=abc123</c>
        /// </remarks>
        /// <param name="confirmDto">Параметры подтверждения email</param>
        /// <returns>204 No Content — если подтверждение прошло успешно</returns>
        /// <response code="204">Email подтверждён успешно</response>
        /// <response code="400">Невалидный токен или email</response>
        /// <response code="404">Пользователь не найден</response>
        [HttpGet("confirm-email")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmDto confirmDto)
        {
            var command = _mapper.Map<ConfirmEmailCommand>(confirmDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
