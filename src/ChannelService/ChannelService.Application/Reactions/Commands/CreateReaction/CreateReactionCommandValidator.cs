using FluentValidation;

namespace ChannelService.Application.Reactions.Commands.CreateReaction
{
    public class CreateReactionCommandValidator : AbstractValidator<CreateReactionCommand>
    {
        public CreateReactionCommandValidator()
        {
            RuleFor(command => command.ActorId)
                .NotEmpty().WithMessage("Actor id must not be empty.");
            RuleFor(command => command.PostId)
                .NotEmpty().WithMessage("Post id must not be empty.");
            RuleFor(command => command.ReactionType)
                .IsInEnum().WithMessage("Wrong reaction type.");
        }
    }
}
