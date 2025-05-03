using FluentValidation;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class GetChannelByHandleQueryValidator : AbstractValidator<GetChannelByHandleQuery>
    {
        public GetChannelByHandleQueryValidator()
        {
            RuleFor(command => command.ChannelHandle)
                .NotEmpty().WithMessage("Handle must not be empty.");
            RuleFor(command => command.ActorId)
                .NotEmpty().WithMessage("Actor ID must not be empty.");
        }
    }
}
