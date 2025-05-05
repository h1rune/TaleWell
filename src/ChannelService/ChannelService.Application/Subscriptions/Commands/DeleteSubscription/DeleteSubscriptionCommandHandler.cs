using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<DeleteSubscriptionCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscriptionEntity = await _dbContext.Subscriptions
                .FirstOrDefaultAsync(subscription => subscription.FollowedId == request.FollowedId &&
                    subscription.FollowerId == request.FollowerId, cancellationToken)
                ?? throw new NotFoundException(nameof(Subscription), request.FollowedId);

            _dbContext.Subscriptions.Remove(subscriptionEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
