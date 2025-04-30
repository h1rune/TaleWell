using MediatR;

namespace ChannelService.Application.Channels.Commands.DeleteChannel
{
    public class DeleteChannelCommand : IRequest<Unit>
    {
        public Guid ChannelId { get; set; }
    }
}
