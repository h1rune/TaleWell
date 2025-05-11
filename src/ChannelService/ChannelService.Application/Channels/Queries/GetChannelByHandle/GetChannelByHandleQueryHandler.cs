using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class GetChannelByHandleQueryHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<GetChannelByHandleQuery, ChannelVm>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<ChannelVm> Handle(GetChannelByHandleQuery request, CancellationToken cancellationToken)
        {
            var channelVm = await _dbContext.Channels
                .Where(channel => channel.Handle == request.ChannelHandle)
                .Select(channel => new ChannelVm
                {
                    Title = channel.Title,
                    Handle = channel.Handle,
                    Description = channel.Description,
                    FollowersNumber = channel.Followers.Count(),
                    IsActorSubscribed = channel.Followers.Any(subscription => subscription.FollowerId == request.ActorId),
                    TariffPlan = channel.TariffPlan,
                })
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.ChannelHandle);

            return channelVm;
        }
    }
}
