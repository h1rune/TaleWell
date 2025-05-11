using FluentValidation;

namespace AuthService.Application.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty();
        }
    }
}
