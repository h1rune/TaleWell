using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Chapters.Commands.DeleteChapter
{
    public class DeleteChapterCommandValidator : AbstractValidator<DeleteChapterCommand>
    {
        public DeleteChapterCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.ChapterId)
                .NotEmpty();

            RuleFor(command => command)
                .MustHaveAccess<DeleteChapterCommand, Chapter>(
                    dbContext, 
                    command => command.ChapterId,
                    command => command.UserId);
        }
    }
}
