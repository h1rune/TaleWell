using ArtService.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Works.Queries.GetWorks
{
    public class GetWorksQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetWorksQuery, WorksVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<WorksVm> Handle(GetWorksQuery request, CancellationToken cancellationToken)
        {
            var worksQuery = await _dbContext.Works
                .Skip(request.Offset)
                .Take(request.Limit)
                .ProjectTo<WorkLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new WorksVm { Works = worksQuery };
        }
    }
}
