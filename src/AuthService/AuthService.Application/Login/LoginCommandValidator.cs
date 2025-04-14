using FluentValidation;

namespace AuthService.Application.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Incorrect email format.");

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
