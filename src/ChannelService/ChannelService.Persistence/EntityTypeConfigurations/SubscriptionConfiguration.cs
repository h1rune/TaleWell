using ChannelService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChannelService.Persistence.EntityTypeConfigurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(subscription => subscription.Id);
            builder.HasIndex(subscription => new { subscription.FollowedId, subscription.FollowerId })
                .IsUnique();

            builder.HasOne(subscription => subscription.Followed)
                .WithMany(channel => channel.Following)
                .HasForeignKey(subscription => subscription.FollowedId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(subscription => subscription.Follower)
                .WithMany(channel => channel.Followers)
                .HasForeignKey(subscription => subscription.FollowerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(subscription => subscription.LastSeenPost)
                .WithMany().HasForeignKey(subscription => subscription.LastSeenPostId);
        }
    }
}
