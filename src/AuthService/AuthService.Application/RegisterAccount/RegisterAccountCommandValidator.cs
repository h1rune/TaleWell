using AuthService.Domain;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.RegisterAccount 
{
    public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        private readonly UserManager<Account> _userManager;

        public RegisterAccountCommandValidator(UserManager<Account> userManager)
        {
            _userManager = userManager;
            RuleFor(command => command.Email)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(UniqueEmail);

            RuleFor(command => command.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches("[A-Z]").WithMessage("Password must contain letter in UPPERCASE.")
                .Matches("[a-z]").WithMessage("Password must contain letter in lowercase.")
                .Matches("[0-9]").WithMessage("Password must contain digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain special symbol.");
        }

        private async Task<bool> UniqueEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null;
        }
    }
}
