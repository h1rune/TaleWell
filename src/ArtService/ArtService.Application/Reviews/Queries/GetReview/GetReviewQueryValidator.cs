using FluentValidation;

namespace ArtService.Application.Reviews.Queries.GetReview
{
    public class GetReviewQueryValidator : AbstractValidator<GetReviewQuery>
    {
        public GetReviewQueryValidator()
        {
            RuleFor(query => query.ReviewId).NotEmpty()
                .WithMessage("ReviewId must not be empty.");
        }
    }
}
