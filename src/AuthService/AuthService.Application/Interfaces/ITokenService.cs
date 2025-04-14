using AuthService.Domain;

namespace AuthService.Application.Interfaces
{
    public interface ITokenService
    {
        Task<TokenDto> GenerateTokensAsync(Account account, CancellationToken cancellationToken);
        Task<TokenDto> RefreshTokenAsync(string refreshTokenValue, string accountId, CancellationToken cancellationToken);
    }
}
