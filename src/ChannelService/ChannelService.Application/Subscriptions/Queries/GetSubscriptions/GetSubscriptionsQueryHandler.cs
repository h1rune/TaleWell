using ChannelService.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Subscriptions.Queries.GetSubscriptions
{
    public class GetSubscriptionsQueryHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<GetSubscriptionsQuery, SubscriptionsVm>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<SubscriptionsVm> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var channels = await _dbContext.Subscriptions
                .Where(subscription => subscription.FollowerId == request.ActorId)
                .Select(subscription => new FollowingChannelDto
                {
                    Title = subscription.Followed!.Title,
                    Handle = subscription.Followed!.Handle,
                    LastPost = new LastPostDto
                    {
                        Text = subscription.LastSeenPost!.Text,
                        CreatedAt = subscription.LastSeenPost.CreatedAt
                    }
                    
                })
                .ToListAsync(cancellationToken);

            return new SubscriptionsVm { Channels = channels };
        }
    }
}
