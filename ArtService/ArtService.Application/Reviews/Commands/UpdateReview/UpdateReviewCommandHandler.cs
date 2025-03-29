using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reviews
                .FirstOrDefaultAsync(review => review.Id == request.ReviewId, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Review), request.ReviewId);
            }

            entity.Mark = request.Mark;
            entity.Text = request.Text;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
