using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;

namespace ChannelService.Application.Reactions.Commands.CreateReaction
{
    public class CreateReactionCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<CreateReactionCommand, Guid>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateReactionCommand request, CancellationToken cancellationToken)
        {
            var reaction = new Reaction
            {
                Id = Guid.NewGuid(),
                PostId = request.PostId,
                ActorId = request.ActorId,
                ReactionType = request.ReactionType,
                PutAt = DateTime.UtcNow
            };

            await _dbContext.Reactions.AddAsync(reaction, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return reaction.Id;
        }
    }
}
