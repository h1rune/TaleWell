using MediatR;

namespace ChannelService.Application.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommand : IRequest<Unit>
    {
        public Guid FollowedId { get; set; }
        public Guid FollowerId { get; set; }
    }
}
