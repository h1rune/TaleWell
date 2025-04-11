using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using FluentValidation;

namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class GetWorkReviewsQueryValidator : AbstractValidator<GetWorkReviewsQuery>
    {
        public GetWorkReviewsQueryValidator(IArtServiceDbContext dbContext)
        {
            Include(new WorkExistsValidator<GetWorkReviewsQuery>(dbContext));
            RuleFor(query => query.Offset).GreaterThanOrEqualTo(0)
                .WithMessage("Offset must be greater than or equal to zero.");
            RuleFor(query => query.Limit).GreaterThan(0)
                .WithMessage("Limit must be greater than zero.");
        }
    }
}
