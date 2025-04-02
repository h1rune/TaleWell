using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Comments
                .FirstOrDefaultAsync(comment => comment.Id == request.CommentId,
                cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Comment), request.CommentId);
            }

            _dbContext.Comments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
