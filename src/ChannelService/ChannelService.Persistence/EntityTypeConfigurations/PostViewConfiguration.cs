using ChannelService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChannelService.Persistence.EntityTypeConfigurations
{
    public class PostViewConfiguration : IEntityTypeConfiguration<PostView>
    {
        public void Configure(EntityTypeBuilder<PostView> builder)
        {
            builder.HasKey(view => view.Id);
            builder.HasIndex(view => new {view.PostId, view.ViewerId}).IsUnique();

            builder.HasOne(view => view.ViewingPost)
                .WithMany(post => post.PostViews)
                .HasForeignKey(view => view.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(view => view.Viewer)
                .WithMany().HasForeignKey(view => view.ViewerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
