using AuthService.Application.Common.Exceptions;
using AuthService.Application.Interfaces;
using AuthService.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.ForgotPassword
{
    public class ForgotPasswordCommandHandler(UserManager<Account> userManager, IEmailService emailService)
        : IRequestHandler<ForgotPasswordCommand, Unit>
    {
        private readonly UserManager<Account> _userManager = userManager;
        private readonly IEmailService _emailService = emailService;

        public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByEmailAsync(request.Email)
                ?? throw new NotFoundException(nameof(Account), request.Email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(account);
            await _emailService.SendPasswordResetEmailAsync(account.Email!, account.Id, token, cancellationToken);
            return Unit.Value;
        }
    }
}
