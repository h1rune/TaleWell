using FluentValidation;

namespace AuthService.Application.ConfirmEmail
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(command => command.AccountId)
                .NotEmpty();

            RuleFor(command => command.Token)
                .NotEmpty();
        }
    }
}
