using MediatR;

namespace ArtService.Application.Works.Queries.GetWork
{
    public class GetWorkQuery : IRequest<WorkVm>
    {
        public Guid WorkId { get; set; }
    }
}
