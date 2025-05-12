using ArtService.Application.Interfaces;
using ArtService.Domain;
using ArtService.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Persistence
{
    public class ArtServiceDbContext(DbContextOptions<ArtServiceDbContext> options) : DbContext(options), IArtServiceDbContext
    {
        public DbSet<Work> Works { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<LiteraryTag> LiteraryTags { get; set; }
        public DbSet<LiteraryArchetype> LiteraryArchetypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new VolumeConfiguration());
            modelBuilder.ApplyConfiguration(new ChapterConfiguration());
            modelBuilder.ApplyConfiguration(new ParagraphConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
            modelBuilder.ApplyConfiguration(new LiteraryTagConfiguration());
            modelBuilder.ApplyConfiguration(new LiteraryArchetypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
