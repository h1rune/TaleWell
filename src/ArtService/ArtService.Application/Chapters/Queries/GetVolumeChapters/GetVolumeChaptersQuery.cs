using MediatR;

namespace ArtService.Application.Chapters.Queries.GetVolumeChapters
{
    public class GetVolumeChaptersQuery : IRequest<VolumeChaptersVm>
    {
        public Guid VolumeId { get; set; }
    }
}
