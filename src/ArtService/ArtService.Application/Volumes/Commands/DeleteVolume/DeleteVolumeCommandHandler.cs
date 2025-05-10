using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Volumes.Commands.DeleteVolume
{
    public class DeleteVolumeCommandHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<DeleteVolumeCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<Unit> Handle(DeleteVolumeCommand request, CancellationToken cancellationToken)
        {
            var volume = await _dbContext.Volumes
                .FirstOrDefaultAsync(volume => volume.Id == request.VolumeId
                    && volume.OwnerId == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(Volume), request.VolumeId);

            if (volume.CoverKey != null)
            {
                await _storageService.DeleteFileAsync(volume.CoverKey, cancellationToken);
            }
      
            _dbContext.Volumes.Remove(volume);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
