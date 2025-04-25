using FluentValidation;

namespace ChannelService.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(command => command.PostId).NotEmpty()
                .WithMessage("Post id must not be empty.");

            RuleFor(command => command.ChannelId).NotEmpty()
                .WithMessage("Channel id must not be empty.");

            RuleFor(command => command.Text)
                .NotEmpty().WithMessage("Post's text must not be empty.")
                .MaximumLength(2000).WithMessage("Too much long post (>2000).");
        }
    }
}
