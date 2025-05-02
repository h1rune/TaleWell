using FluentValidation;

namespace ChannelService.Application.Reactions.Commands.DeleteReaction
{
    public class DeleteReactionCommandValidator : AbstractValidator<DeleteReactionCommand>
    {
        public DeleteReactionCommandValidator()
        {
            RuleFor(command => command.ReactionId)
                .NotEmpty().WithMessage("Reaction ID must not be empty.");
            RuleFor(command => command.ActorId)
                .NotEmpty().WithMessage("Actor ID must not be empty.");
        }
    }
}
