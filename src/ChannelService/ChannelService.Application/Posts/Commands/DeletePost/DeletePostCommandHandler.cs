using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postEntity = await _dbContext.Posts
                .FirstOrDefaultAsync(post => post.Id == request.PostId
                    && post.ChannelId == request.ChannelId, cancellationToken)
                ?? throw new NotFoundException(nameof(Post), request.PostId);

            _dbContext.Posts.Remove(postEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
