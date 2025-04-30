using AuthService.Domain;
using MediatR;

namespace AuthService.Application.TokenRefresh
{
    public class RefreshTokenCommand : IRequest<TokensDto>
    {
        public required string RefreshToken { get; set; }
    }
}
