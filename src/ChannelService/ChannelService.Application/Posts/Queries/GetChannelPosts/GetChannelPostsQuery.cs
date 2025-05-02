using MediatR;

namespace ChannelService.Application.Posts.Queries.GetChannelPosts
{
    public class GetChannelPostsQuery : IRequest<ChannelPostsVm>
    {
        public Guid ActorId { get; set; }
        public required string ChannelHandle { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
