using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AuthServiceDbContext dbContext)
        {
            dbContext.Database.Migrate();
        }
    }
}
