using ChannelService.Application.Common.Mappings;
using ChannelService.Domain;

namespace ChannelService.Application.Subscriptions.Queries.GetSubscriptions
{
    public class LastPostDto : IMapWith<Post>
    {
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
