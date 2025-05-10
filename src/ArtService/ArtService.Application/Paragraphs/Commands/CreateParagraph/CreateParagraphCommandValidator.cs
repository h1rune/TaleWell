using FluentValidation;

namespace ArtService.Application.Paragraphs.Commands.CreateParagraph
{
    public class CreateParagraphCommandValidator : AbstractValidator<CreateParagraphCommand>
    {
        public CreateParagraphCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.ChapterId)
                .NotEmpty();

            RuleFor(command => command.Order)
                .GreaterThan(0);

            RuleFor(command => command.Text)
                .NotEmpty();
        }
    }
}
