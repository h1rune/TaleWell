using Microsoft.EntityFrameworkCore;

namespace ArtService.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(ArtServiceDbContext dbContext)
        {
            dbContext.Database.Migrate();
        }
    }
}
