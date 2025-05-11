using FluentValidation;

namespace AuthService.Application.Logout
{
    public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(command => command.RefreshToken)
                .NotEmpty();
        }
    }
}
