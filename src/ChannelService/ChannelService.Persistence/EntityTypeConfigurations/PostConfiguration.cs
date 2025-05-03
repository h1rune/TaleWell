using ChannelService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChannelService.Persistence.EntityTypeConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(post => post.Id);
            builder.HasIndex(post => post.ChannelId);
            builder.Property(post => post.Text).HasMaxLength(2000);

            builder.HasOne(post => post.Channel)
                .WithMany(channel => channel.Posts)
                .HasForeignKey(post => post.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
