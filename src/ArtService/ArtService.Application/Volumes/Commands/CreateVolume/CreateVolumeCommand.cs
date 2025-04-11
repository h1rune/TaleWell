using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArtService.Application.Volumes.Commands.CreateVolume
{
    public class CreateVolumeCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid WorkId { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public IFormFile? CoverFile { get; set; }
    }
}
