using FluentValidation;

namespace ArtService.Application.Works.Queries.GetWork
{
    public class GetWorkQueryValidator : AbstractValidator<GetWorkQuery>
    {
        public GetWorkQueryValidator()
        {
            RuleFor(query => query.WorkId)
                .NotEmpty();
        }
    }
}
