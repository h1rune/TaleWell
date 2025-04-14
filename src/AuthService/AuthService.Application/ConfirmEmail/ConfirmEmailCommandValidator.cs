using FluentValidation;

namespace AuthService.Application.ConfirmEmail
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(command => command.AccountId)
                .NotEmpty().WithMessage("Account ID is required.");

            RuleFor(command => command.Token)
                .NotEmpty().WithMessage("Token is required.");
        }
    }
}
