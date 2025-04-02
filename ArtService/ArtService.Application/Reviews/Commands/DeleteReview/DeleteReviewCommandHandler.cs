using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reviews
                .FirstOrDefaultAsync(review => review.Id == request.ReviewId, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Review), request.ReviewId);
            }

            _dbContext.Reviews.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
