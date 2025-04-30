using MediatR;

namespace ChannelService.Application.Channels.Commands.UpdateChannel
{
    public class UpdateChannelCommand : IRequest<Unit>
    {
        public Guid ChannelId { get; set; }
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public string? Description { get; set; }
    }
}
