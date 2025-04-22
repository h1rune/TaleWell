using AuthService.Domain;

namespace AuthService.Application.Interfaces
{
    public interface ITokenService
    {
        Task<TokensDto> GenerateTokensAsync(Account account, CancellationToken cancellationToken);
        Task<TokensDto> RefreshTokenAsync(string refreshTokenValue, CancellationToken cancellationToken);
    }
}
