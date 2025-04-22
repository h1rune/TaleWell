using AuthService.Domain;
using MediatR;

namespace AuthService.Application.TokenRefresh
{
    public class RefreshTokenCommand : IRequest<TokensDto>
    {
        public string RefreshToken { get; set; } = null!;
    }
}
