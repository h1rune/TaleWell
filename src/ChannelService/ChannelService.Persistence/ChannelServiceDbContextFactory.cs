using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChannelService.Persistence
{
    public class ChannelServiceDbContextFactory
        : IDesignTimeDbContextFactory<ChannelServiceDbContext>
    {
        public ChannelServiceDbContext CreateDbContext(string[] args)
        {
            var connection = "Host=localhost;Port=5433;Database=art;Username=user;Password=password";

            var optionsBuilder = new DbContextOptionsBuilder<ChannelServiceDbContext>();
            optionsBuilder.UseNpgsql(connection);

            return new ChannelServiceDbContext(optionsBuilder.Options);
        }
    }
}
