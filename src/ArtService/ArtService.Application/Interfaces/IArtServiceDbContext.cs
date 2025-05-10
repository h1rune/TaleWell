using ArtService.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Interfaces
{
    public interface IArtServiceDbContext
    {
        DbSet<Work> Works { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Volume> Volumes { get; set; }
        DbSet<Chapter> Chapters { get; set; }
        DbSet<Paragraph> Paragraphs { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Reaction> Reactions { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
