using FluentValidation;

namespace ArtService.Application.Works.Queries.GetWorksByOwner
{
    public class GetWorksByOwnerQueryValidator : AbstractValidator<GetWorksByOwnerQuery>
    {
        public GetWorksByOwnerQueryValidator()
        {
            RuleFor(query => query.OwnerHandle).NotEmpty();
        }
    }
}
