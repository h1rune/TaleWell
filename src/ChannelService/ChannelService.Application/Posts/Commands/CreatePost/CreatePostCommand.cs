using MediatR;

namespace ChannelService.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<Guid>
    {
        public Guid ChannelId { get; set; }
        public required string Text { get; set; }
    }
}