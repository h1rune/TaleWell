using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Paragraphs.Commands.DeleteParagraph
{
    public class DeleteParagraphCommandHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<DeleteParagraphCommand>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task Handle(DeleteParagraphCommand request, CancellationToken cancellationToken)
        {
            var paragraph = await _dbContext.Paragraphs
                .Include(paragraph => paragraph.RelatedChapter.RelatedVolume.RelatedWork)
                .FirstOrDefaultAsync(paragraph => paragraph.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Paragraph), request.Id);

            var work = paragraph.RelatedChapter.RelatedVolume.RelatedWork;
            if (work.AuthorId != request.UserId)
            {
                throw new NotFoundException(nameof(Work), work.Id);
            }
            
            await _storageService.DeleteFileAsync(paragraph.S3Key, cancellationToken);
            _dbContext.Paragraphs.Remove(paragraph);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
