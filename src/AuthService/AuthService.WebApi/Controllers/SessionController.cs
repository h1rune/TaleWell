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

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto loginDto)
        {
            var command = _mapper.Map<LoginCommand>(loginDto);
            var token = await Mediator.Send(command);

            Response.Cookies.Append("access_token", token.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddMinutes(60)
            });

            return Ok(token);
        }

        [HttpPost("logout-all")]
        public async Task<IActionResult> LogoutAll([FromBody] LogoutAllDto logoutAllDto)
        {
            Response.Cookies.Delete("access_token");
            var command = _mapper.Map<LogoutAllCommand>(logoutAllDto);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenDto>> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var command = _mapper.Map<RefreshTokenCommand>(refreshTokenDto);
            var token = await Mediator.Send(command);
            return Ok(token);
        }
    }
}
