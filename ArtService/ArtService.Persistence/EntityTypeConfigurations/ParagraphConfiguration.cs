using ArtService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class ParagraphConfiguration : IEntityTypeConfiguration<Paragraph>
    {
        public void Configure(EntityTypeBuilder<Paragraph> builder)
        {
            builder.HasKey(paragraph => paragraph.Id);
            builder.HasIndex(paragraph => new {paragraph.ChapterId, paragraph.Order});

            builder.HasOne(paragraph => paragraph.RelatedChapter)
                .WithMany(chapter => chapter.Paragraphs)
                .HasForeignKey(paragraph => paragraph.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
