using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Reactions.Commands.SwitchReaction
{
    public class SwitchReactionCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<SwitchReactionCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(SwitchReactionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reactions
                .FirstOrDefaultAsync(reaction => reaction.ParagraphId == request.ParagraphId &&
                reaction.UserId == request.UserId &&
                reaction.Type == request.Type, cancellationToken);

            if (entity == null)
            {
                var reaction = new Reaction
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId,
                    ParagraphId = request.ParagraphId,
                    Type = request.Type,
                    PutAt = DateTime.UtcNow
                };

                await _dbContext.Reactions.AddAsync(reaction, cancellationToken);
            }
            else
            {
                _dbContext.Reactions.Remove(entity);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
