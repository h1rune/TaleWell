using ArtService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(work => work.Id);
            builder.HasIndex(work => work.OwnerId);

            builder.Property(work => work.Description).HasMaxLength(1000);

            builder.HasOne(work => work.OriginalWork)
                .WithMany(original => original.Fanfics)
                .HasForeignKey(work => work.OriginalWorkId);
        }
    }
}
