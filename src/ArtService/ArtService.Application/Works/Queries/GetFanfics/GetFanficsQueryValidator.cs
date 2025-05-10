using FluentValidation;

namespace ArtService.Application.Works.Queries.GetFanfics
{
    public class GetFanficsQueryValidator : AbstractValidator<GetFanficsQuery>
    {
        public GetFanficsQueryValidator()
        {
            RuleFor(query => query.OriginalId)
                .NotEmpty();

            RuleFor(query => query.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(query => query.Limit)
                .GreaterThan(0);
        }
    }
}
