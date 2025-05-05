using FluentValidation;

namespace ChannelService.Application.Subscriptions.Queries.GetSubscriptions
{
    public class GetSubscriptionsQueryValidator : AbstractValidator<GetSubscriptionsQuery>
    {
        public GetSubscriptionsQueryValidator()
        {
            RuleFor(query => query.ActorId)
                .NotEmpty().WithMessage("Actor ID must not be empty.");
        }
    }
}
