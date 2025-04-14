using AuthService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Application.Interfaces
{
    public interface IAuthServiceDbContext
    {
        DbSet<RefreshToken> RefreshTokens { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
