using FluentValidation;

namespace ArtService.Application.Works.Queries.GetWorks
{
    public class GetWorksQueryValidator : AbstractValidator<GetWorksQuery>
    {
        public GetWorksQueryValidator()
        {
            RuleFor(query => query.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(query => query.Limit)
                .GreaterThan(0);
        }
    }
}
