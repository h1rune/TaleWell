using ArtService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.HasKey(reaction => reaction.Id);
            builder.HasIndex(reaction => reaction.ParagraphId);

            builder.Property(reaction => reaction.PutAt).HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(reaction => reaction.RelatedParagraph)
                .WithMany(paragraph => paragraph.Reactions)
                .HasForeignKey(reaction => reaction.ParagraphId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
