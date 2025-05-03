using FluentValidation;

namespace ChannelService.Application.PostViews.Commands.CreatePostView
{
    public class CreatePostViewCommandValidator : AbstractValidator<CreatePostViewCommand>
    {
        public CreatePostViewCommandValidator()
        {
            RuleFor(command => command.ViewerId)
                .NotEmpty().WithMessage("Viewer ID must be not empty.");
            RuleFor(command => command.PostId)
                .NotEmpty().WithMessage("Post ID must be not empty.");
        }
    }
}
