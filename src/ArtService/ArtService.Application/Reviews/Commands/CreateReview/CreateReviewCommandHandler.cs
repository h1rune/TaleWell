using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;

namespace ArtService.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<CreateReviewCommand, Guid>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                OwnerId = request.UserId,
                OwnerHandle = request.OwnerHandle,
                WorkId = request.WorkId,
                Mark = request.Mark,
                Text = request.Text,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Reviews.AddAsync(review, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return review.Id;
        }
    }
}
