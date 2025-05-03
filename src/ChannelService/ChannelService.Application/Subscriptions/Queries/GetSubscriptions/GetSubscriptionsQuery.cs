using MediatR;

namespace ChannelService.Application.Subscriptions.Queries.GetSubscriptions
{
    public class GetSubscriptionsQuery : IRequest<SubscriptionsVm>
    {
        public Guid ActorId { get; set; }
    }
}
