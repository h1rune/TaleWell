using MediatR;

namespace ArtService.Application.Volumes.Queries.GetVolume
{
    public class GetVolumeQuery : IRequest<VolumeVm>
    {
        public Guid VolumeId { get; set; }
    }
}
