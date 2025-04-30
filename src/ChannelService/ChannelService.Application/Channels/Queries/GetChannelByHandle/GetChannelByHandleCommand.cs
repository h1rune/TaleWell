using MediatR;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class GetChannelByHandleCommand : IRequest<ChannelVm>
    {
        public required string Handle { get; set; }
    }
}
