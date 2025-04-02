using FluentValidation;

namespace ArtService.Application.Works.Queries.GetFanfics
{
    public class GetFanficsQueryValidator : AbstractValidator<GetFanficsQuery>
    {
        public GetFanficsQueryValidator()
        {
            RuleFor(query => query.OriginalId).NotEmpty()
                .WithMessage("Original work id must not be empty.");
            RuleFor(query => query.Offset).GreaterThanOrEqualTo(0)
                .WithMessage("Offset must be greater than or equal zero.");
            RuleFor(query => query.Limit).GreaterThan(0)
                .WithMessage("Limit must be greater than zero.");
        }
    }
}
