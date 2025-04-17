using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Persistence
{
    public class ArtServiceDbContextFactory : IDesignTimeDbContextFactory<ArtServiceDbContext>
    {
        public ArtServiceDbContext CreateDbContext(string[] args)
        {
            var connection = "Host=localhost;Port=5433;Database=art;Username=user;Password=password";

            var optionsBuilder = new DbContextOptionsBuilder<ArtServiceDbContext>();
            optionsBuilder.UseNpgsql(connection);

            return new ArtServiceDbContext(optionsBuilder.Options);
        }
    }
}
