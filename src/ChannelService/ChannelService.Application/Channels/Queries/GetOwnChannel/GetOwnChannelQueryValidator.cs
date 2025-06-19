using FluentValidation;

namespace ChannelService.Application.Channels.Queries.GetOwnChannel
{
    public class GetOwnChannelQueryValidator : AbstractValidator<GetOwnChannelQuery>
    {
        public GetOwnChannelQueryValidator()
        {
            RuleFor(query => query.ActorId)
                .NotEmpty();
        }
    }
}
