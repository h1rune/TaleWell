using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Channels.Queries.GetOwnChannel
{
    public class GetOwnChannelQueryHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<GetOwnChannelQuery, OwnChannelVm>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<OwnChannelVm> Handle(GetOwnChannelQuery request, CancellationToken cancellationToken)
        {
            var channelVm = await _dbContext.Channels
                .Where(channel => channel.Id == request.ActorId)
                .Select(channel => new OwnChannelVm
                {
                    Title = channel.Title,
                    Handle = channel.Handle,
                    TariffPlan = channel.TariffPlan,
                })
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.ActorId);

            return channelVm;
        }
    }
}
