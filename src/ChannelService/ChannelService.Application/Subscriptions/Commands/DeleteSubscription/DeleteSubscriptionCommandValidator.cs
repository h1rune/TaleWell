using FluentValidation;

namespace ChannelService.Application.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
    {
        public DeleteSubscriptionCommandValidator()
        {
            RuleFor(command => command.FollowedId)
                .NotEmpty().WithMessage("Subscription ID must not be empty.");
            RuleFor(command => command.FollowerId)
                .NotEmpty().WithMessage("Actor ID must not be empty.");
        }
    }
}
