using ArtService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.HasKey(chapter => chapter.Id);
            builder.HasIndex(chapter => new {chapter.WorkId, chapter.Order});

            builder.HasOne(chapter => chapter.RelatedWork)
                .WithMany(work => work.Chapters)
                .HasForeignKey(chapter => chapter.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
