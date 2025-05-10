using FluentValidation;

namespace ArtService.Application.Volumes.Queries.GetWorkVolumes
{
    public class GetWorkVolumesQueryValidator
        : AbstractValidator<GetWorkVolumesQuery>
    {
        public GetWorkVolumesQueryValidator()
        {
            RuleFor(query => query.WorkId)
                .NotEmpty();
        }
    }
}
