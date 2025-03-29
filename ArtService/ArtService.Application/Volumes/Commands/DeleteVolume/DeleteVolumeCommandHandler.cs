using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Volumes.Commands.DeleteVolume
{
    public class DeleteVolumeCommandHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<DeleteVolumeCommand>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task Handle(DeleteVolumeCommand request, CancellationToken cancellationToken)
        {
            var volume = await _dbContext.Volumes
                .Include(volume => volume.RelatedWork)
                .FirstOrDefaultAsync(volume => volume.Id == request.VolumeId, cancellationToken)
                ?? throw new NotFoundException(nameof(Volume), request.VolumeId);

            if (volume.RelatedWork.AuthorId != request.UserId)
            {
                throw new NotFoundException(nameof(Work), volume.WorkId);
            }

            if (volume.CoverKey != null)
            {
                await _storageService.DeleteFileAsync(volume.CoverKey, cancellationToken);
            }
      
            _dbContext.Volumes.Remove(volume);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
