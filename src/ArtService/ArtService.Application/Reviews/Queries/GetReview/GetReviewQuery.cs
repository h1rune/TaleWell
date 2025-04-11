using MediatR;

namespace ArtService.Application.Reviews.Queries.GetReview
{
    public class GetReviewQuery : IRequest<ReviewVm>
    {
        public Guid ReviewId { get; set; }
    }
}
