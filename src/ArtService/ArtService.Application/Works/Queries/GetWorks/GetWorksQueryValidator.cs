using FluentValidation;

namespace ArtService.Application.Works.Queries.GetWorks
{
    public class GetWorksQueryValidator : AbstractValidator<GetWorksQuery>
    {
        public GetWorksQueryValidator()
        {
            RuleFor(query => query.Offset).GreaterThanOrEqualTo(0)
                .WithMessage("Offset must be greater than or equal zero.");
            RuleFor(query => query.Limit).GreaterThan(0)
                .WithMessage("Limit must be greater than zero.");
        }
    }
}
