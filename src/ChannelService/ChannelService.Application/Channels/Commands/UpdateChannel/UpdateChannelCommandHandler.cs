using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Channels.Commands.UpdateChannel
{
    public class UpdateChannelCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<UpdateChannelCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateChannelCommand request, CancellationToken cancellationToken)
        {
            var channelEntity = await _dbContext.Channels
                .FirstOrDefaultAsync(channel => channel.Id == request.ChannelId, cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.ChannelId);

            channelEntity.Title = request.Title;
            channelEntity.Handle = request.Handle;
            channelEntity.Description = request.Description;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
