using MediatR;

namespace ArtService.Application.Works.Queries.GetWorks
{
    public class GetWorksQuery : IRequest<WorksVm>
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 5;
    }
}
