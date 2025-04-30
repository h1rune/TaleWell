using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;

namespace ChannelService.Application.Channels.Commands.CreateChannel
{
    public class CreateChannelCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<CreateChannelCommand, Guid>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;
        
        public async Task<Guid> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
        {
            var channel = new Channel
            {
                Id = request.ChannelId,
                Title = request.Title,
                Handle = request.Handle,
                Description = request.Description,
            };

            await _dbContext.Channels.AddAsync(channel, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return channel.Id;
        }
    }
}
