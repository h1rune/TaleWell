using ArtService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ArtService.Application.Reactions.Queries.GetParagraphReactions
{
    public class GetParagraphReactionsQueryHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<GetParagraphReactionsQuery, ParagraphReactionsVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<ParagraphReactionsVm> Handle(GetParagraphReactionsQuery request, CancellationToken cancellationToken)
        {
            var reactionCounts = await _dbContext.Reactions
                .Where(reaction => reaction.ParagraphId == request.ParagraphId)
                .GroupBy(reaction => reaction.Type)
                .Select(group => new ReactionCountDto
                {
                    Type = group.Key,
                    Count = group.Count(),
                    IsUserPut = group.Any(reaction => reaction.UserId == request.UserId)
                })
                .ToListAsync(cancellationToken);

            return new ParagraphReactionsVm { Reactions = reactionCounts };
        }
    }
}
