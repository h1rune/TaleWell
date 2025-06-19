using ChannelService.Domain;

namespace ChannelService.Application.Channels.Queries.GetOwnChannel
{
    public class OwnChannelVm
    {
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public TariffPlan TariffPlan { get; set; }
    }
}
