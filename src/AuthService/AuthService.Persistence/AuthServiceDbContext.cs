using AuthService.Application.Interfaces;
using AuthService.Domain;
using AuthService.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence
{
    public class AuthServiceDbContext(DbContextOptions<AuthServiceDbContext> options) : DbContext(options), IAuthServiceDbContext
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseOpenIddict();
        }
    }
}
