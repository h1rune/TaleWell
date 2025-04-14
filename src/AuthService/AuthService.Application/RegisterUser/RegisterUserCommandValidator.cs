using FluentValidation;

namespace AuthService.Application.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Incorrect email format.");

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be longer than 6 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain letter in UPPERCASE.")
                .Matches("[a-z]").WithMessage("Password must contain letter in lowercase.")
                .Matches("[0-9]").WithMessage("Password must contain digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain special symbol.");
        }
    }
}
