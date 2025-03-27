using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler(IArtServiceDbContext dbContext) : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Comments
                .FirstOrDefaultAsync(comment => comment.Id == request.Id, 
                cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            } 

            entity.Text = request.Text;
            entity.IsSpoiler = request.IsSpoiler;
            entity.SpoilerChapterNumber = request.SpoilerChapterNumber;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
