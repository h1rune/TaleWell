using MediatR;

namespace ChannelService.Application.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommand : IRequest<Unit>
    {
        public Guid SubscriptionId { get; set; }
        public Guid ActorId { get; set; }
    }
}
