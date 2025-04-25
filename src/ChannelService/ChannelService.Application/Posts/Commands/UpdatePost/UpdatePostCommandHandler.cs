using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<UpdatePostCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var postEntity = await _dbContext.Posts
                .FirstOrDefaultAsync(post => post.Id == request.PostId
                    && post.ChannelId == request.ChannelId, cancellationToken)
                ?? throw new NotFoundException(nameof(Post), request.PostId);

            postEntity.Text = request.Text;
            postEntity.EditedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
