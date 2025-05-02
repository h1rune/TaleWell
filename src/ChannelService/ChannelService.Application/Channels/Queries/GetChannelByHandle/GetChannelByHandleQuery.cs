using MediatR;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class GetChannelByHandleQuery : IRequest<ChannelVm>
    {
        public required string Handle { get; set; }
    }
}
