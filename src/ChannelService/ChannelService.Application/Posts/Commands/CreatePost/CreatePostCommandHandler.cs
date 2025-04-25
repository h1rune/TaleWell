using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;

namespace ChannelService.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = new()
            {
                Id = Guid.NewGuid(),
                ChannelId = request.ChannelId,
                Text = request.Text,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Posts.AddAsync(post, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return post.Id;
        }
    }
}
