using FluentValidation;

namespace ArtService.Application.Volumes.Commands.UpdateVolume
{
    public class UpdateVolumeCommandValidator : AbstractValidator<UpdateVolumeCommand>
    {
        public UpdateVolumeCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.VolumeId)
                .NotEmpty();

            RuleFor(command => command.Order)
                .GreaterThan(0);
        }
    }
}
