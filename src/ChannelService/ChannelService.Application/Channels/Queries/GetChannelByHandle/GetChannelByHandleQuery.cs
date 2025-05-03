using MediatR;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class GetChannelByHandleQuery : IRequest<ChannelVm>
    {
        public Guid ActorId { get; set; }
        public required string ChannelHandle { get; set; }
    }
}
