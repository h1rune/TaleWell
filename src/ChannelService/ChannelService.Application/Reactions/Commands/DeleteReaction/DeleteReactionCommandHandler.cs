using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Reactions.Commands.DeleteReaction
{
    public class DeleteReactionCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<DeleteReactionCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteReactionCommand request, CancellationToken cancellationToken)
        {
            var reactionEntity = await _dbContext.Reactions
                .FirstOrDefaultAsync(reaction => reaction.Id == request.ReactionId &&
                    reaction.ActorId == request.ActorId, cancellationToken)
                ?? throw new NotFoundException(nameof(Reaction), request.ReactionId);

            _dbContext.Reactions.Remove(reactionEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
