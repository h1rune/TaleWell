using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Paragraphs.Commands.CreateParagraph
{
    public class CreateParagraphCommandHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<CreateParagraphCommand, Guid>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<Guid> Handle(CreateParagraphCommand request, CancellationToken cancellationToken)
        {
            var chapter = await _dbContext.Chapters
                .Include(chapter => chapter.RelatedVolume.RelatedWork)
                .FirstOrDefaultAsync(chapter => chapter.Id == request.ChapterId, cancellationToken)
                ?? throw new NotFoundException(nameof(Chapter), request.ChapterId);

            var work = chapter.RelatedVolume.RelatedWork;
            if (work.AuthorId != request.UserId)
            {
                throw new NotFoundException(nameof(Work), work.Id);
            }


            var paragraphId = Guid.NewGuid();
            var path = $"works/{work.Id}/volumes/{chapter.RelatedVolume.Id}/chapters/{chapter.Id}/paragraphs/{paragraphId}.txt";
            var paragraph = new Paragraph
            {
                Id = paragraphId,
                ChapterId = chapter.Id,
                Order = request.Order,
                S3Key = await _storageService.UploadFileAsync(request.Text, path, cancellationToken)
            };

            await _dbContext.Paragraphs.AddAsync(paragraph, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return paragraph.Id;
        }
    }
}
