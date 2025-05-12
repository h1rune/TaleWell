using ArtService.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.LiteraryTags.Queries.GetLiteraryTags
{
    public class GetLiteraryTagsQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetLiteraryTagsQuery, LiteraryTagsVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<LiteraryTagsVm> Handle(GetLiteraryTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _dbContext.LiteraryTags
                .OrderBy(tag => tag.Name)
                .ProjectTo<LiteraryTagLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new LiteraryTagsVm { LiteraryTags = tags };
        }
    }
}
