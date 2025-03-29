using ArtService.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Chapters.Queries.GetVolumeChapters
{
    public class GetVolumeChaptersQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetVolumeChaptersQuery, VolumeChaptersVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<VolumeChaptersVm> Handle(GetVolumeChaptersQuery request, CancellationToken cancellationToken)
        {
            var chaptersQuery = await _dbContext.Chapters
                .Where(chapter => chapter.VolumeId == request.VolumeId)
                .ProjectTo<ChapterLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new VolumeChaptersVm { Chapters = chaptersQuery };
        }
    }
}
