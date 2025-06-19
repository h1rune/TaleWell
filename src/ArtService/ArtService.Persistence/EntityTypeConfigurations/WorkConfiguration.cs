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
            builder.HasIndex(work => work.OwnerHandle);

            builder.Property(work => work.Description)
                .HasMaxLength(1000);

            builder.HasOne(work => work.OriginalWork)
                .WithMany(original => original.Fanfics)
                .HasForeignKey(work => work.OriginalWorkId);

            builder.HasOne(work => work.LiteraryArchetype)
                .WithMany(archetype => archetype.Works)
                .HasForeignKey(work => work.LiteraryArchetypeId);

            builder.HasMany(work => work.Tags)
                .WithMany(tag => tag.Works);
        }
    }
}
