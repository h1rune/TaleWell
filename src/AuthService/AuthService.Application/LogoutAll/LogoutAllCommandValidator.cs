using FluentValidation;

namespace AuthService.Application.LogoutAll
{
    public class LogoutAllCommandValidator : AbstractValidator<LogoutAllCommand>
    {
        public LogoutAllCommandValidator()
        {
            RuleFor(command => command.AccountId)
                .NotEmpty().WithMessage("Account ID is required.");
        }
    }
}
