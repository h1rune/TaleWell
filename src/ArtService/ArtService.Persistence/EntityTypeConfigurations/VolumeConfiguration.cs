using ArtService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class VolumeConfiguration : IEntityTypeConfiguration<Volume>
    {
        public void Configure(EntityTypeBuilder<Volume> builder)
        {
            builder.HasKey(volume => volume.Id);
            builder.HasIndex(volume => new { volume.WorkId, volume.Order });

            builder.HasOne(volume => volume.RelatedWork)
                .WithMany(work => work.Volumes)
                .HasForeignKey(volume => volume.WorkId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
