using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Paragraphs.Commands.DeleteParagraph
{
    public class DeleteParagraphCommandHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<DeleteParagraphCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<Unit> Handle(DeleteParagraphCommand request, CancellationToken cancellationToken)
        {
            var paragraph = await _dbContext.Paragraphs
                .FirstOrDefaultAsync(paragraph => paragraph.Id == request.ParagraphId
                    && paragraph.OwnerId == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(Paragraph), request.ParagraphId);
            
            await _storageService.DeleteFileAsync(paragraph.S3Key, cancellationToken);
            _dbContext.Paragraphs.Remove(paragraph);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
