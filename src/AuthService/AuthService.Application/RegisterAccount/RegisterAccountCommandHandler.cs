using AuthService.Application.Interfaces;
using AuthService.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.RegisterAccount
{
    public class RegisterAccountCommandHandler(UserManager<Account> userManager, IEmailService emailService)
        : IRequestHandler<RegisterAccountCommand, string>
    {
        private readonly UserManager<Account> _userManager = userManager;
        private readonly IEmailService _emailService = emailService;

        public async Task<string> Handle(RegisterAccountCommand command, CancellationToken cancellationToken)
        {
            var account = new Account { Email = command.Email };
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(account);
            await _emailService.SendEmailConfirmationAsync(account.Email, account.Id, token, cancellationToken);
            await _userManager.CreateAsync(account, command.Password);
            return account.Id;
        }
    }
}
