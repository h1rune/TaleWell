using FluentValidation;

namespace ArtService.Application.Volumes.Queries.GetVolume
{
    public class GetVolumeQueryValidator : AbstractValidator<GetVolumeQuery>
    {
        public GetVolumeQueryValidator()
        {
            RuleFor(query => query.VolumeId)
                .NotEmpty();
        }
    }
}
