using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Chapters.Queries.GetChapter
{
    public class GetChapterQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetChapterQuery, ChapterVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ChapterVm> Handle(GetChapterQuery request, CancellationToken cancellationToken)
        {
            var chapterEntity = await _dbContext.Chapters
                .FirstOrDefaultAsync(chapter => chapter.Id == request.ChapterId, cancellationToken)
                ?? throw new NotFoundException(nameof(Chapter), request.ChapterId);

            return _mapper.Map<ChapterVm>(chapterEntity);
        }
    }
}
