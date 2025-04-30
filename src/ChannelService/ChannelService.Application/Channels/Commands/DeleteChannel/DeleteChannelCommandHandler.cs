using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Channels.Commands.DeleteChannel
{
    public class DeleteChannelCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<DeleteChannelCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteChannelCommand request, CancellationToken cancellationToken)
        {
            var channelEntity = await _dbContext.Channels
                .FirstOrDefaultAsync(channel => channel.Id == request.ChannelId, cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.ChannelId);

            _dbContext.Channels.Remove(channelEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
