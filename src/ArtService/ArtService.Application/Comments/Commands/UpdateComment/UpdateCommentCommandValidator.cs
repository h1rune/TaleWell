using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.CommentId)
                .NotEmpty();

            RuleFor(command => command.Text)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(command => command.SpoilerChapterId)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(command => command.SpoilerChapterId!.Value)
                        .MustExistInDb<UpdateCommentCommand, Chapter>(dbContext);
                })
                .When(command => command.IsSpoiler);
        }
    }
}
