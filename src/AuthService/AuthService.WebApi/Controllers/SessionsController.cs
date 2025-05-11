using AuthService.Application.Login;
using AuthService.Application.Logout;
using AuthService.Application.TokenRefresh;
using AuthService.Domain;
using AuthService.WebApi.Models.Session;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AuthService.WebApi.Controllers
{
    public class SessionsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;
        private readonly CookieOptions _cookieOptions = new()
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None
        };

        [HttpPost("login")]
        [SwaggerResponse(StatusCodes.Status200OK, "Login successed", typeof(Cookie))]
        [EndpointDescription("Login into the account by email and password.")]
        public async Task<IActionResult> Login(
            [FromBody, SwaggerRequestBody("Login credentials")] 
            LoginDto loginDto, 
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<LoginCommand>(loginDto);
            var tokens = await Mediator.Send(command, cancellationToken);
            SetCookies(tokens);
            return Ok();
        }

        [HttpPost("logout")]
        [SwaggerResponse(StatusCodes.Status200OK, "Logout successed")]
        [EndpointDescription("Logout from all sessions of the account.")]
        public async Task<IActionResult> LogoutAll(CancellationToken cancellationToken)
        {
            if (!Request.Cookies.TryGetValue("refresh_token", out var refreshToken))
                return Unauthorized();

            var command = new LogoutCommand { RefreshToken = refreshToken };
            await Mediator.Send(command, cancellationToken);
            Response.Cookies.Delete("access_token");
            Response.Cookies.Delete("refresh_token");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [SwaggerResponse(StatusCodes.Status200OK, "Token was refreshed")]
        [EndpointDescription("Refresh access token for the account.")]
        public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken)
        {
            if (!Request.Cookies.TryGetValue("refresh_token", out var refreshToken))
                return Unauthorized();

            var command = new RefreshTokenCommand { RefreshToken = refreshToken };
            var tokens = await Mediator.Send(command, cancellationToken);
            SetCookies(tokens);
            return Ok();
        }

        private void SetCookies(TokensDto tokensDto)
        {
            _cookieOptions.Expires = tokensDto.AccessExpiresAt;
            Response.Cookies.Append("access_token", tokensDto.AccessToken, _cookieOptions);
            _cookieOptions.Expires = tokensDto.RefreshExpiresAt;
            Response.Cookies.Append("refresh_token", tokensDto.RefreshToken, _cookieOptions);
        }
    }
}
