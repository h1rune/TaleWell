using MediatR;

namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class GetWorkReviewsQuery : IRequest<WorkReviewsVm>
    {
        public Guid WorkId { get; set; }
    }
}
