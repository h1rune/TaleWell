using MediatR;

namespace ArtService.Application.Volumes.Commands.DeleteVolume
{
    public class DeleteVolumeCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
