using MediatR;

namespace ChannelService.Application.Posts.Queries.GetChannelPosts
{
    public class GetChannelPostsQuery : IRequest<ChannelPostsVm>
    {
        public Guid ChannelId { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
