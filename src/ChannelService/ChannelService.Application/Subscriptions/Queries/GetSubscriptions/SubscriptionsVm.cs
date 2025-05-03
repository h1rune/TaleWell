namespace ChannelService.Application.Subscriptions.Queries.GetSubscriptions
{
    public class SubscriptionsVm
    {
        public IList<FollowingChannelDto> Channels { get; set; } = [];
    }
}
