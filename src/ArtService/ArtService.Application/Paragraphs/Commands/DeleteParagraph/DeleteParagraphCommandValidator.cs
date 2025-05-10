using FluentValidation;

namespace ArtService.Application.Paragraphs.Commands.DeleteParagraph
{
    public class DeleteParagraphCommandValidator : AbstractValidator<DeleteParagraphCommand>
    {
        public DeleteParagraphCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.ParagraphId)
                .NotEmpty();
        }
    }
}
