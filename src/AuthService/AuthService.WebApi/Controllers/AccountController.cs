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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var command = _mapper.Map<RegisterAccountCommand>(registerDto);
            var accountId = await Mediator.Send(command);
            return Ok(accountId);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmDto confirmDto)
        {
            var command = _mapper.Map<ConfirmEmailCommand>(confirmDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
