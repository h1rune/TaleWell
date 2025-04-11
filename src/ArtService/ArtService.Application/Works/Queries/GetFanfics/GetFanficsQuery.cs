using MediatR;

namespace ArtService.Application.Works.Queries.GetFanfics
{
    public class GetFanficsQuery : IRequest<FanficsVm>
    {
        public Guid OriginalId { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 5;
    }
}
