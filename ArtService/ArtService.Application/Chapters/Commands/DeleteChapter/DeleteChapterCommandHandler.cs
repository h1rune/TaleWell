using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Chapters.Commands.DeleteChapter
{
    public class DeleteChapterCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<DeleteChapterCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = await _dbContext.Chapters
                .FirstOrDefaultAsync(chapter => chapter.Id == request.ChapterId, cancellationToken)
                ?? throw new NotFoundException(nameof(Chapter), request.ChapterId);

            var volume = await _dbContext.Volumes
                .Include(volume => volume.RelatedWork)
                .FirstOrDefaultAsync(volume => volume.Id == chapter.VolumeId, cancellationToken)
                ?? throw new NotFoundException(nameof(Volume), chapter.VolumeId);

            if (volume.RelatedWork == null || volume.RelatedWork.AuthorId != request.UserId)
            {
                throw new NotFoundException(nameof(Work), volume.WorkId);
            }

            _dbContext.Chapters.Remove(chapter);    
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
