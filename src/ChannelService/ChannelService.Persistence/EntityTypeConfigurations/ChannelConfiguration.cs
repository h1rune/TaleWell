using ChannelService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChannelService.Persistence.EntityTypeConfigurations
{
    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.HasKey(channel => channel.Id);
            builder.HasIndex(channel => channel.Handle).IsUnique();
            builder.Property(channel => channel.Title).HasMaxLength(200);
            builder.Property(channel => channel.Handle).HasMaxLength(30);
            builder.HasMany(channel => channel.Posts)
                .WithOne(post => post.Channel)
                .HasForeignKey(post => post.ChannelId);
        }
    }
}