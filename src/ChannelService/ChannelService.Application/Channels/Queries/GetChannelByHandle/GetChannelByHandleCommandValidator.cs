using FluentValidation;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class GetChannelByHandleCommandValidator : AbstractValidator<GetChannelByHandleCommand>
    {
        public GetChannelByHandleCommandValidator()
        {
            RuleFor(command => command.Handle)
                .NotEmpty().WithMessage("Handle must not be empty.");
        }
    }
}
