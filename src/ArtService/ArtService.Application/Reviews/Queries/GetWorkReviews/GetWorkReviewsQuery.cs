using MediatR;

namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class GetWorkReviewsQuery : IRequest<WorkReviewsVm>
    {
        public Guid WorkId { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 5;
    }
}
