namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class WorkReviewsVm
    {
        public required IList<WorkReviewLookupDto> Reviews { get; set; }
    }
}
