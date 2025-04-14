using AuthService.Application.Interfaces;
using AuthService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AuthService.Infrastructure
{
    public class TokenCleanupService(IServiceScopeFactory scopeFactory, ILogger<TokenCleanupService> logger) 
        : BackgroundService, ITokenCleanupService
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
        private readonly ILogger<TokenCleanupService> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromHours(6));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                await CleanupExpiredTokensAsync(stoppingToken);
            }
        }

        public async Task CleanupExpiredTokensAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AuthServiceDbContext>();

            try
            {
                var expiredTokens = await dbContext.RefreshTokens
                    .Where(token => token.ExpiresAt < DateTime.UtcNow || token.IsRevoked)
                    .ToListAsync(cancellationToken);

                if (expiredTokens.Any())
                {
                    dbContext.RefreshTokens.RemoveRange(expiredTokens);
                    await dbContext.SaveChangesAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении expired refresh-токенов");
            }
        }
    }

}
