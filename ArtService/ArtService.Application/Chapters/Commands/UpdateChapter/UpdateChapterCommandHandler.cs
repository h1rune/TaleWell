using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Chapters.Commands.UpdateChapter
{
    public class UpdateChapterCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<UpdateChapterCommand>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = await _dbContext.Chapters
                .FirstOrDefaultAsync(chapter => chapter.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Chapter), request.Id);

            var volume = await _dbContext.Volumes
                .Include(volume => volume.RelatedWork)
                .FirstOrDefaultAsync(volume => volume.Id == chapter.VolumeId, cancellationToken)
                ?? throw new NotFoundException(nameof(Volume), chapter.VolumeId);

            if (volume.RelatedWork == null || volume.RelatedWork.AuthorId != request.UserId)
            {
                throw new NotFoundException(nameof(Work), volume.WorkId);
            }

            chapter.Title = request.Title;
            chapter.Order = request.Order;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
