using MediatR;

namespace ChannelService.Application.PostViews.Commands.CreatePostView
{
    public class CreatePostViewCommand : IRequest<Unit>
    {
        public Guid PostId { get; set; }
        public Guid ViewerId { get; set; }
    }
}
