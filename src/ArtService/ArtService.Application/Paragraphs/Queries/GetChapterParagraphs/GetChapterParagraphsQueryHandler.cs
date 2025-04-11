using ArtService.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Paragraphs.Queries.GetChapterParagraphs
{
    public class GetChapterParagraphsQueryHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<GetChapterParagraphsQuery, ChapterParagraphsVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<ChapterParagraphsVm> Handle(GetChapterParagraphsQuery request, CancellationToken cancellationToken)
        {
            var paragraphsQuery = await _dbContext.Paragraphs
                .Where(paragraph => paragraph.ChapterId == request.ChapterId)
                .OrderBy(paragraph => paragraph.Order)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToListAsync(cancellationToken);

            var paragraphsDto = new List<ParagraphLookupDto>();

            foreach (var paragraph in paragraphsQuery)
            {
                string fileContent = await _storageService.ReadFileByKeyAsync(paragraph.S3Key, cancellationToken);
                var paragraphDto = new ParagraphLookupDto
                {
                    Id = paragraph.Id,
                    Order = paragraph.Order,
                    Text = fileContent
                };
                paragraphsDto.Add(paragraphDto);
            }

            return new ChapterParagraphsVm { Paragraphs = paragraphsDto };
        }
    }
}
