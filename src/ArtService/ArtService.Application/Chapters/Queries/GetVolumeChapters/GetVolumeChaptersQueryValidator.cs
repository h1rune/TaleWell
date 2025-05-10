using FluentValidation;

namespace ArtService.Application.Chapters.Queries.GetVolumeChapters
{
    public class GetVolumeChaptersQueryValidator : AbstractValidator<GetVolumeChaptersQuery>
    {
        public GetVolumeChaptersQueryValidator()
        {
            RuleFor(command => command.VolumeId)
                .NotEmpty();
        }
    }
}
