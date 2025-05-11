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
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<PostView> PostViews { get; set; }
        public DbSet<TariffPayment> TariffPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChannelConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new PostViewConfiguration());
            modelBuilder.ApplyConfiguration(new TariffPaymentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
