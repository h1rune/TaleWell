using FluentValidation;

namespace ArtService.Application.Paragraphs.Commands.UpdateParagraph
{
    public class UpdateParagraphCommandValidator : AbstractValidator<UpdateParagraphCommand>
    {
        public UpdateParagraphCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.ParagraphId)
                .NotEmpty();

            RuleFor(command => command.Order)
                .GreaterThan(0);

            RuleFor(command => command.Text)
                .NotEmpty();
        }
    }
}
