using MediatR;

namespace ChannelService.Application.Channels.Commands.CreateChannel
{
    public class CreateChannelCommand : IRequest<Unit>
    {
        public Guid ChannelId { get; set; }
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public string? Description { get; set; }
    }
}
