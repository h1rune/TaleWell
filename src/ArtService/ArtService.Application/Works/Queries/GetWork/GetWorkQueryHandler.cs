using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Works.Queries.GetWork
{
    public class GetWorkQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetWorkQuery, WorkVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<WorkVm> Handle(GetWorkQuery request, CancellationToken cancellationToken)
        {
            var workEntity = await _dbContext.Works
                .FirstOrDefaultAsync(work => work.Id == request.WorkId, cancellationToken)
                ?? throw new NotFoundException(nameof(Work), request.WorkId);

            return _mapper.Map<WorkVm>(workEntity);
        }
    }
}
