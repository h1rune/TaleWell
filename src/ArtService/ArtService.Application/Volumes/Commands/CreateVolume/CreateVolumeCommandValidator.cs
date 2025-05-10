using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Volumes.Commands.CreateVolume
{
    public class CreateVolumeCommandValidator : AbstractValidator<CreateVolumeCommand>
    {
        public CreateVolumeCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.WorkId)
                .NotEmpty();

            RuleFor(command => command)
                .MustHaveAccess<CreateVolumeCommand, Work>(
                    dbContext,
                    command => command.WorkId,
                    command => command.UserId);

            RuleFor(command => command.Order)
                .GreaterThan(0);              
        }
    }
}
