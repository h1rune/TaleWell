using FluentValidation;

namespace AuthService.Application.TokenRefresh
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(command => command.AccountId)
                .NotEmpty().WithMessage("Account ID is required.");

            RuleFor(command => command.RefreshToken)
                .NotEmpty().WithMessage("Refresh token is required.");
        }
    }
}
