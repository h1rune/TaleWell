using ArtService.Application.Works.Queries.GetWorks;
using MediatR;

namespace ArtService.Application.Works.Queries.GetWorksByOwner
{
    public class GetWorksByOwnerQuery : IRequest<WorksVm>
    {
        public required string OwnerHandle { get; set; }
    }
}
