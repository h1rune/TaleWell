using FluentValidation;

namespace ChannelService.Application.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
    {
        public DeleteSubscriptionCommandValidator()
        {
            RuleFor(command => command.SubscriptionId)
                .NotEmpty().WithMessage("Subscription ID must not be empty.");
            RuleFor(command => command.ActorId)
                .NotEmpty().WithMessage("Actor ID must not be empty.");
        }
    }
}
