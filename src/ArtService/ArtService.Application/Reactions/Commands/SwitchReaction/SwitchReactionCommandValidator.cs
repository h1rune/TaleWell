using FluentValidation;

namespace ArtService.Application.Reactions.Commands.SwitchReaction
{
    public class SwitchReactionCommandValidator : AbstractValidator<SwitchReactionCommand>
    {
        public SwitchReactionCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.ParagraphId)
                .NotEmpty();

            RuleFor(command => command.Type)
                .IsInEnum();
        }
    }
}
