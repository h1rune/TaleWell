using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Paragraphs.Queries.GetParagraph
{
    public class GetParagraphQueryHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<GetParagraphQuery, ParagraphVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<ParagraphVm> Handle(GetParagraphQuery request, CancellationToken cancellationToken)
        {
            var paragraphEntity = await _dbContext.Paragraphs
                .FirstOrDefaultAsync(paragrph => paragrph.Id == request.ParagraphId, cancellationToken)
                ?? throw new NotFoundException(nameof(Paragraph), request.ParagraphId);

            return new ParagraphVm
            {
                ChapterId = paragraphEntity.ChapterId,
                Order = paragraphEntity.Order,
                Text = await _storageService.ReadFileByKeyAsync(paragraphEntity.S3Key, cancellationToken)
            };
        }
    }
}
