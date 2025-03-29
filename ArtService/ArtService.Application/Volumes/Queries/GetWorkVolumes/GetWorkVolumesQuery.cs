using MediatR;

namespace ArtService.Application.Volumes.Queries.GetWorkVolumes
{
    public class GetWorkVolumesQuery : IRequest<WorkVolumesVm>
    {
        public Guid WorkId { get; set; }
    }
}
