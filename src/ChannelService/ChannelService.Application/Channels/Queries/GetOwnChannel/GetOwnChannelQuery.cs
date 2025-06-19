using MediatR;

namespace ChannelService.Application.Channels.Queries.GetOwnChannel
{
    public class GetOwnChannelQuery : IRequest<OwnChannelVm>
    {
        public Guid ActorId { get; set; }
    }
}
