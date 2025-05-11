using FluentValidation;

namespace AuthService.Application.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(command => command.AccountId)
                .NotEmpty();

            RuleFor(command => command.Token)
                .NotEmpty();

            RuleFor(command => command.NewPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Matches("[A-Z]").WithMessage("Password must contain letter in UPPERCASE.")
                .Matches("[a-z]").WithMessage("Password must contain letter in lowercase.")
                .Matches("[0-9]").WithMessage("Password must contain digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain special symbol.");
        }
    }
}
