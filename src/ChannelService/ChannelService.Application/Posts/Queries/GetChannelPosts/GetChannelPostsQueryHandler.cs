using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Posts.Queries.GetChannelPosts
{
    public class GetChannelPostsQueryHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<GetChannelPostsQuery, ChannelPostsVm>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<ChannelPostsVm> Handle(GetChannelPostsQuery request, CancellationToken cancellationToken)
        {
            var channelEntity = await _dbContext.Channels
                .FirstOrDefaultAsync(channel => channel.Handle == request.ChannelHandle, cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.ChannelHandle);

            var posts = await _dbContext.Posts
                .Where(post => post.ChannelId == channelEntity.Id)
                .Include(p => p.Reactions)
                .OrderBy(post => post.CreatedAt)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToListAsync(cancellationToken);

            var postDtos = posts.Select(post => new PostLookupDto
            {
                Id = post.Id,
                Text = post.Text,
                CreatedAt = post.CreatedAt,
                EditedAt = post.EditedAt,
                Reactions = [.. post.Reactions
                    .GroupBy(reaction => reaction.ReactionType)
                    .Select(group => new ReactionSummaryDto
                    {
                        ReactionType = group.Key,
                        Count = group.Count(),
                        CurrentUserReactionId = group.FirstOrDefault(reaction => 
                            reaction.ActorId == request.ActorId)?.Id
                    })
                ]
            })
            .ToList();

            return new ChannelPostsVm { Posts = postDtos };
        }
    }
}
