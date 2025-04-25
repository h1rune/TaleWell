using MediatR;

namespace ChannelService.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<Unit>
    {
        public Guid PostId { get; set; }
        public Guid ChannelId { get; set; }
        public required string Text { get; set; }
    }
}
