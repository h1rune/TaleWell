using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.OwnerHandle)
                .NotEmpty();

            RuleFor(command => command.ParagraphId)
                .MustExistInDb<CreateCommentCommand, Paragraph>(dbContext);

            RuleFor(command => command.Text)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(command => command.SpoilerChapterId)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(command => command.SpoilerChapterId!.Value)
                        .MustExistInDb<CreateCommentCommand, Chapter>(dbContext);
                })
                .When(command => command.IsSpoiler);
        }
    }
}
