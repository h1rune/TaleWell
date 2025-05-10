using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Chapters.Commands.UpdateChapter
{
    public class UpdateChapterCommandValidator : AbstractValidator<UpdateChapterCommand>
    {
        public UpdateChapterCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();
            RuleFor(command => command.ChapterId)
                .NotEmpty();

            RuleFor(command => command)
                .MustHaveAccess<UpdateChapterCommand, Chapter>(
                    dbContext,
                    command => command.ChapterId,
                    command => command.UserId);

            RuleFor(command => command.Order)
                .GreaterThan(0);
        }
    }
}
