using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.PostViews.Commands.CreatePostView
{
    public class CreatePostViewCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<CreatePostViewCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(CreatePostViewCommand request, CancellationToken cancellationToken)
        {
            var channelExistsTask = _dbContext.Channels
                .AnyAsync(channel => channel.Id == request.ViewerId, cancellationToken);
            var postExistsTask = _dbContext.Posts
                .AnyAsync(post => post.Id == request.PostId, cancellationToken);

            await Task.WhenAll(channelExistsTask, postExistsTask);

            if (!channelExistsTask.Result)
                throw new NotFoundException(nameof(Channel), request.ViewerId);
            if (!postExistsTask.Result)
                throw new NotFoundException(nameof(Post), request.PostId);

            var postView = new PostView
            {
                Id = Guid.NewGuid(),
                PostId = request.PostId,
                ViewerId = request.ViewerId,
                ViewedAt = DateTime.UtcNow
            };

            await _dbContext.PostViews.AddAsync(postView, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
