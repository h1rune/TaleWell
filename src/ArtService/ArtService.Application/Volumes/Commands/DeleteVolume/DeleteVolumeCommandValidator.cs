using FluentValidation;

namespace ArtService.Application.Volumes.Commands.DeleteVolume
{
    public class DeleteVolumeCommandValidator
        : AbstractValidator<DeleteVolumeCommand>
    {
        public DeleteVolumeCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.VolumeId)
                .NotEmpty();
        }
    }
}
