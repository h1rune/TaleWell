using MediatR;

namespace ArtService.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<Unit>
    {
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
    }
}
