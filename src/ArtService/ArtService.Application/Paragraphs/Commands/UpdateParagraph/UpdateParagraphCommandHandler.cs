using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Paragraphs.Commands.UpdateParagraph
{
    public class UpdateParagraphCommandHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<UpdateParagraphCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<Unit> Handle(UpdateParagraphCommand request, CancellationToken cancellationToken)
        {
            var paragraph = await _dbContext.Paragraphs
                .Include(paragraph => paragraph.RelatedChapter.RelatedVolume.RelatedWork)
                .FirstOrDefaultAsync(paragraph => paragraph.Id == request.ParagraphId, cancellationToken)
                ?? throw new NotFoundException(nameof(Paragraph), request.ParagraphId);

            var work = paragraph.RelatedChapter.RelatedVolume.RelatedWork;
            if (work.AuthorId != request.UserId)
            {
                throw new NotFoundException(nameof(Work), work.Id);
            }

            var chapter = paragraph.RelatedChapter;
            var path = $"works/{work.Id}/volumes/{chapter.RelatedVolume.Id}/chapters/{chapter.Id}/paragraphs/{paragraph.Id}.txt";
            paragraph.Order = request.Order;
            paragraph.S3Key = await _storageService.UploadFileAsync(request.Text, path, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
