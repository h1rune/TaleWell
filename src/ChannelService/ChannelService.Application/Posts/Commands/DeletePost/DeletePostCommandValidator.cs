using FluentValidation;

namespace ChannelService.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(command => command.PostId)
                .NotEmpty().WithMessage("Post id must not be empty.");
            RuleFor(command => command.ChannelId)
                .NotEmpty().WithMessage("Channel id must not be empty.");
        }
    }
}
