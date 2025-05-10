using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;

namespace ArtService.Application.Chapters.Commands.CreateChapter
{
    public class CreateChapterCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<CreateChapterCommand, Guid>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = new Chapter
            {
                Id = Guid.NewGuid(),
                VolumeId = request.VolumeId,
                Order = request.Order,
                Title = request.Title,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Chapters.AddAsync(chapter, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return chapter.Id;
        }
    }
}
