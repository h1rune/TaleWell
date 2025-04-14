namespace AuthService.Application.Interfaces
{
    public interface ITokenCleanupService
    {
        Task CleanupExpiredTokensAsync(CancellationToken cancellationToken);
    }
}
