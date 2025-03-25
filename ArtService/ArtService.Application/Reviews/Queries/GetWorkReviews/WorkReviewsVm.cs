namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class WorkReviewsVm
    {
        public required IList<ReviewLookupDto> Reviews { get; set; }
    }
}
