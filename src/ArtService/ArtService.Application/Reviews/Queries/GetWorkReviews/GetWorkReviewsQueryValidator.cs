using FluentValidation;

namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class GetWorkReviewsQueryValidator : AbstractValidator<GetWorkReviewsQuery>
    {
        public GetWorkReviewsQueryValidator()
        {
            RuleFor(query => query.WorkId)
                .NotEmpty();
            RuleFor(query => query.Offset)
                .GreaterThanOrEqualTo(0);
            RuleFor(query => query.Limit)
                .GreaterThan(0);
        }
    }
}
