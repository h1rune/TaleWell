namespace ArtService.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ArtServiceDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
