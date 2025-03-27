using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArtService.Application.Volumes.Commands.UpdateVolume
{
    public class UpdateVolumeCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public IFormFile? CoverFile { get; set; }
    }
}
