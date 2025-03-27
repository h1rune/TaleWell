using MediatR;

namespace ArtService.Application.Works.Queries.GetFanfics
{
    public class GetFanficsQuery : IRequest<FanficsVm>
    {
        public Guid OriginalId { get; set; }
    }
}
