using Microsoft.EntityFrameworkCore;

namespace ChannelService.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ChannelServiceDbContext dbContext)
        {
            dbContext.Database.Migrate();
        }
    }
}
