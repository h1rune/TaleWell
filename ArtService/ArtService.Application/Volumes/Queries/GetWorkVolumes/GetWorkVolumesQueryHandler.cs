using ArtService.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Volumes.Queries.GetWorkVolumes
{
    public class GetWorkVolumesQueryHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<GetWorkVolumesQuery, WorkVolumesVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<WorkVolumesVm> Handle(GetWorkVolumesQuery request, CancellationToken cancellationToken)
        {
            var volumesQuery = await _dbContext.Volumes
                .Where(volume => volume.WorkId == request.WorkId)
                .OrderBy(volume => volume.Order)
                .Select(volume => new VolumeLookupDto
                {
                    Id = volume.Id,
                    Order = volume.Order,
                    Title = volume.Title,
                    CoverUrl = volume.CoverKey != null ? 
                        _storageService.GeneratePreSignedUrl(volume.CoverKey, TimeSpan.FromHours(1)) : null,
                })
                .ToListAsync(cancellationToken);

            return new WorkVolumesVm { Volumes = volumesQuery };
        }
    }
}
