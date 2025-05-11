using AuthService.Application.Common.Exceptions;
using AuthService.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.ResetPassword
{
    public class ResetPasswordCommandHandler(UserManager<Account> userManager)
        : IRequestHandler<ResetPasswordCommand, Unit>
    {
        private readonly UserManager<Account> _userManager = userManager;

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.AccountId)
                ?? throw new NotFoundException(nameof(Account), request.AccountId);
            var result = await _userManager.ResetPasswordAsync(account, request.Token, request.NewPassword);

            if(!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            return Unit.Value;
        }
    }
}
