using MediatR;

namespace ArtService.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest
    {
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
    }
}
