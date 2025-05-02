using FluentValidation;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class GetChannelByHandleQueryValidator : AbstractValidator<GetChannelByHandleQuery>
    {
        public GetChannelByHandleQueryValidator()
        {
            RuleFor(command => command.Handle)
                .NotEmpty().WithMessage("Handle must not be empty.");
        }
    }
}
