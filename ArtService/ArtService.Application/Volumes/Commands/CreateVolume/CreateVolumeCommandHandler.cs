using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;

namespace ArtService.Application.Volumes.Commands.CreateVolume
{
    public class CreateVolumeCommandHandler(IArtServiceDbContext dbContext, IStorageService storageService)
     : IRequestHandler<CreateVolumeCommand, Guid>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IStorageService _storageService = storageService;

        public async Task<Guid> Handle(CreateVolumeCommand request, CancellationToken cancellationToken)
        {
            var volume = new Volume
            {
                Id = Guid.NewGuid(),
                Order = request.Order,
                Title = request.Title,
                WorkId = request.WorkId
            };

            if (request.CoverFile != null)
            {
                var path = $"works/{request.WorkId}/covers/{Guid.NewGuid()}-{request.CoverFile.FileName}";
                var coverKey = await _storageService.UploadFileAsync(request.CoverFile, path, cancellationToken);
                volume.CoverKey = coverKey;
            }

            await _dbContext.Volumes.AddAsync(volume, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);   
            return volume.Id;
        }
    }
}
