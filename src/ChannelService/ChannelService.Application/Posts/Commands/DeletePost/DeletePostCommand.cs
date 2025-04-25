using MediatR;

namespace ChannelService.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public Guid PostId { get; set; }
        public Guid ChannelId { get; set; }
    }
}
