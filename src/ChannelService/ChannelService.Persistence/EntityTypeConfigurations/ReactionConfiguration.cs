using ChannelService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChannelService.Persistence.EntityTypeConfigurations
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.HasKey(reaction => reaction.Id);
            builder.HasIndex(reaction => reaction.PostId);

            builder.HasOne(reaction => reaction.Post)
                .WithMany(post => post.Reactions)
                .HasForeignKey(reaction => reaction.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(reaction => reaction.Actor)
                .WithMany()
                .HasForeignKey(reaction => reaction.ActorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
