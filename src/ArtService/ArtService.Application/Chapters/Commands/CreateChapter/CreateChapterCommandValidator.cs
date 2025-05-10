using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Chapters.Commands.CreateChapter
{
    public class CreateChapterCommandValidator : AbstractValidator<CreateChapterCommand>
    {
        public CreateChapterCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.VolumeId)
                .NotEmpty();

            RuleFor(command => command)
                .MustHaveAccess<CreateChapterCommand, Volume>(
                    dbContext, 
                    command => command.VolumeId, 
                    command => command.UserId);

            RuleFor(command => command.Order)
                .GreaterThan(0);
        }
    }
}
