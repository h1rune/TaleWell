using FluentValidation;

namespace AuthService.Application.TokenRefresh
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(command => command.RefreshToken)
                .NotEmpty().WithMessage("Refresh token is required.");
        }
    }
}
