using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Chapters.Commands.UpdateChapter
{
    public class UpdateChapterCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<UpdateChapterCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = await _dbContext.Chapters
                .FirstOrDefaultAsync(chapter => chapter.Id == request.ChapterId, cancellationToken)
                ?? throw new NotFoundException(nameof(Chapter), request.ChapterId);

            chapter.Title = request.Title;
            chapter.Order = request.Order;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
