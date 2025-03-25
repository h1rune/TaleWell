using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;

namespace ArtService.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler(IArtServiceDbContext dbContext) 
        : IRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                Id = new Guid(),
                UserId = request.UserId,
                ParagraphId = request.ParagraphId,
                Text = request.Text,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Comments.AddAsync(comment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }
    }
}
