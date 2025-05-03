using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;

namespace ChannelService.Application.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<CreateSubscriptionCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                FollowedId = request.FollowedId,
                FollowerId = request.FollowerId,
                SubscribedAt = DateTime.UtcNow
            };

            await _dbContext.Subscriptions.AddAsync(subscription, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
