using ChannelService.Domain;

namespace ChannelService.Application.Subscriptions.Queries.GetSubscriptions
{
    public class FollowingChannelDto
    {
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public LastPostDto? LastPost { get; set; }
        public TariffPlan TariffPlan { get; set; }
    }
}
