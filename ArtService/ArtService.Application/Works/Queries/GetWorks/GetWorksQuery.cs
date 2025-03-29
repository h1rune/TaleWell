using MediatR;

namespace ArtService.Application.Works.Queries.GetWorks
{
    public class GetWorksQuery : IRequest<WorksVm>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
