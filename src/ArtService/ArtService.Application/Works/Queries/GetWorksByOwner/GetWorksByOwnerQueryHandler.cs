using ArtService.Application.Interfaces;
using ArtService.Application.Works.Queries.GetWorks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Works.Queries.GetWorksByOwner
{
    public class GetWorksByOwnerQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetWorksByOwnerQuery, WorksVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<WorksVm> Handle(GetWorksByOwnerQuery request, CancellationToken cancellationToken)
        {
            var works = await _dbContext.Works
                .Include(work => work.Tags)
                .Include(work => work.LiteraryArchetype)
                .OrderBy(work => work.CreatedAt)
                .Where(work => work.OwnerHandle == request.OwnerHandle)
                .ProjectTo<WorkLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new WorksVm { Works = works };
        }
    }
}
