using ChannelService.Domain;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class ChannelVm
    {
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public string? Description { get; set; }
        public int FollowersNumber { get; set; }
        public bool IsActorSubscribed { get; set; }
        public TariffPlan TariffPlan { get; set; }
    }
}