using ChannelService.Application.Common.Mappings;
using ChannelService.Application.Subscriptions.Commands.CreateSubscription;

namespace ChannelService.WebApi.Models.SubscriptionModels
{
    public class CreateSubscriptionDto : IMapWith<CreateSubscriptionCommand>
    {
        public Guid FollowedId { get; set; }
    }
}
