using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AuthService.Persistence
{
    public class AuthServiceDbContextFactory : IDesignTimeDbContextFactory<AuthServiceDbContext>
    {
        public AuthServiceDbContext CreateDbContext(string[] args)
        {
            var connection = "Host=localhost;Port=5433;Database=auth;Username=user;Password=password";

            var optionsBuilder = new DbContextOptionsBuilder<AuthServiceDbContext>();
            optionsBuilder.UseNpgsql(connection);

            return new AuthServiceDbContext(optionsBuilder.Options);
        }
    }
}