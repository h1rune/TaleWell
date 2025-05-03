using MediatR;

namespace ChannelService.Application.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommand : IRequest<Unit>
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }
    }
}
