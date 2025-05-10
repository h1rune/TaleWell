using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler(IArtServiceDbContext dbContext) 
        : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = await _dbContext.Comments
                .FirstOrDefaultAsync(comment => comment.Id == request.CommentId, 
                cancellationToken);

            if (commentEntity == null || commentEntity.OwnerId != request.UserId)
            {
                throw new NotFoundException(nameof(Comment), request.CommentId);
            } 

            commentEntity.Text = request.Text;
            commentEntity.IsSpoiler = request.IsSpoiler;
            commentEntity.SpoilerChapterId = request.IsSpoiler ? request.SpoilerChapterId : null;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
