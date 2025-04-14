using AuthService.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.ConfirmEmail
{
    public class ConfirmEmailCommandHandler(UserManager<Account> userManager)
        : IRequestHandler<ConfirmEmailCommand, Unit>
    {
        private readonly UserManager<Account> _userManager = userManager;

        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.AccountId) 
                ?? throw new ArgumentException("Invalid user.");

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);
            if (!result.Succeeded)
                throw new Exception("Email confirmation failed.");

            return Unit.Value;
        }
    }
}
