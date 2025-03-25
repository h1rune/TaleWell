using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Comments
                .FirstOrDefaultAsync(comment => comment.Id == request.Id,
                cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }

            _dbContext.Comments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
