using MediatR;

namespace ArtService.Application.Volumes.Commands.DeleteVolume
{
    public class DeleteVolumeCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid VolumeId { get; set; }
    }
}
