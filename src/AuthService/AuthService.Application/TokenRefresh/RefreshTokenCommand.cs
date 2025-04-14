using AuthService.Domain;
using MediatR;

namespace AuthService.Application.TokenRefresh
{
    public class RefreshTokenCommand : IRequest<TokenDto>
    {
        public string RefreshToken { get; set; } = null!;
        public string AccountId { get; set; } = null!;
    }
}
