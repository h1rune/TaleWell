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
            builder.HasIndex(chapter => new {chapter.VolumeId, chapter.Order});

            builder.HasOne(chapter => chapter.RelatedVolume)
                .WithMany(volume => volume.Chapters)
                .HasForeignKey(chapter => chapter.VolumeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
