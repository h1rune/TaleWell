using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Volumes.Queries.GetVolume
{
    public class GetVolumeQueryHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<GetVolumeQuery, VolumeVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<VolumeVm> Handle(GetVolumeQuery request, CancellationToken cancellationToken)
        {
            var volumeEntity = await _dbContext.Volumes
                .FirstOrDefaultAsync(volume => volume.Id == request.VolumeId, cancellationToken)
                ?? throw new NotFoundException(nameof(Volume), request.VolumeId);

            return new VolumeVm
            {
                WorkId = volumeEntity.WorkId,
                Order = volumeEntity.Order,
                Title = volumeEntity.Title,
                CoverUrl = volumeEntity.CoverKey != null ?
                    _storageService.GeneratePreSignedUrl(volumeEntity.CoverKey, TimeSpan.FromHours(1)) : null
            };
        }
    }
}
