using ArtService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(review => review.Id);
            builder.HasIndex(review => review.Id);

            builder.Property(review => review.Text).HasMaxLength(2000);
            builder.Property(review => review.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(review => review.ReviewedWork)
                .WithMany(work => work.Reviews)
                .HasForeignKey(review => review.WorkId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
