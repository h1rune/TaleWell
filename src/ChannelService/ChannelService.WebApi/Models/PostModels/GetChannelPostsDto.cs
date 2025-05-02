using ChannelService.Application.Common.Mappings;
using ChannelService.Application.Posts.Queries.GetChannelPosts;

namespace ChannelService.WebApi.Models.PostModels
{
    public class GetChannelPostsDto : IMapWith<GetChannelPostsQuery>
    {
        public required string ChannelHandle { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
