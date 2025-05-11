using AuthService.Application.ConfirmEmail;
using AuthService.Application.ForgotPassword;
using AuthService.Application.RegisterAccount;
using AuthService.Application.ResetPassword;
using AuthService.WebApi.Models.Account;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthService.WebApi.Controllers
{
    public class AccountsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
        [SwaggerResponse(StatusCodes.Status201Created, "Register successed", typeof(string))]
        [EndpointDescription("Register new account and send email confirmation.")]
        public async Task<IActionResult> Register(
            [FromBody, SwaggerRequestBody("Registration data")] 
            RegisterDto registerDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<RegisterAccountCommand>(registerDto);
            await Mediator.Send(command, cancellationToken);
            var confirmEndpoint = Url.Action(nameof(ConfirmEmail), "Accounts");
            return Created(confirmEndpoint, new { });
        }
      
        [HttpGet("confirm-email")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Register successed")]
        [EndpointDescription("Email confirmation for account.")]
        public async Task<IActionResult> ConfirmEmail(
            [FromQuery, SwaggerParameter("Confirmation data")] 
            ConfirmDto confirmDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<ConfirmEmailCommand>(confirmDto);
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPost("{email}/forgot-password")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Confirmation was sent.")]
        [EndpointDescription("Send email confirmation to reset password.")]
        public async Task<IActionResult> ForgotPassword(
            [SwaggerParameter("Account email")]
            string email,
            CancellationToken cancellationToken)
        {
            var command = new ForgotPasswordCommand { Email = email };
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPost("reset-password")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Password was updated")]
        [EndpointDescription("Resets account password and applies new one.")]
        public async Task<IActionResult> ResetPassword(
            [FromBody, SwaggerRequestBody("Reset data")]
            ResetPasswordDto resetDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<ResetPasswordCommand>(resetDto);
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
