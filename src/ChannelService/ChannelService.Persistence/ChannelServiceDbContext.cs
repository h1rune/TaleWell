using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using ChannelService.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Persistence
{
    public class ChannelServiceDbContext(DbContextOptions<ChannelServiceDbContext> options)
        : DbContext(options), IChannelServiceDbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Channel> Channels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChannelConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
