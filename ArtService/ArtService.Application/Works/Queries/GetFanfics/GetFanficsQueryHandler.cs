using ArtService.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Works.Queries.GetFanfics
{
    public class GetFanficsQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetFanficsQuery, FanficsVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<FanficsVm> Handle(GetFanficsQuery request, CancellationToken cancellationToken)
        {
            var fanficsQuery = await _dbContext.Works
                .Where(work => work.OriginalWorkId == request.OriginalId)
                .OrderBy(work => work.CreatedAt)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ProjectTo<FanficLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FanficsVm { Fanfics = fanficsQuery };
        }
    }
}
