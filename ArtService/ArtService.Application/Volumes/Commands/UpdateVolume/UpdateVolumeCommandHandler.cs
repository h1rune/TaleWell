using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Volumes.Commands.UpdateVolume
{
    public class UpdateVolumeCommandHandler(IArtServiceDbContext dbContext, IStorageService storageService)
        : IRequestHandler<UpdateVolumeCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<Unit> Handle(UpdateVolumeCommand request, CancellationToken cancellationToken)
        {
            var volume = await _dbContext.Volumes
                .Include(volume => volume.RelatedWork)
                .FirstOrDefaultAsync(volume => volume.Id == request.VolumeId, cancellationToken)
                ?? throw new NotFoundException(nameof(Volume), request.VolumeId);

            if (volume.RelatedWork.AuthorId != request.UserId)
            {
                throw new NotFoundException(nameof(Work), volume.WorkId);
            } 

            volume.Order = request.Order;
            volume.Title = request.Title;

            if (request.CoverFile != null)
            {
                var path = $"works/{volume.WorkId}/covers/{Guid.NewGuid()}-{request.CoverFile.FileName}";
                var coverKey = await _storageService.UploadFileAsync(request.CoverFile, path, cancellationToken);
                volume.CoverKey = coverKey;
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
