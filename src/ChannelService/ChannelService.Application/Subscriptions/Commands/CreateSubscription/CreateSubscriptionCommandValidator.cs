using FluentValidation;

namespace ChannelService.Application.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
    {
        public CreateSubscriptionCommandValidator()
        {
            RuleFor(command => command.FollowedId)
                .NotEmpty().WithMessage("Followed ID must not be empty.");
            RuleFor(command => command.FollowerId)
                .NotEmpty().WithMessage("Follower ID must not be empty.");
        }
    }
}
