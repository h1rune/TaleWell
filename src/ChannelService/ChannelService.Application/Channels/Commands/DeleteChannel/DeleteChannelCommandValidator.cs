using FluentValidation;

namespace ChannelService.Application.Channels.Commands.DeleteChannel
{
    public class DeleteChannelCommandValidator : AbstractValidator<DeleteChannelCommand>
    {
        public DeleteChannelCommandValidator()
        {
            RuleFor(command => command.ChannelId)
                .NotEmpty().WithMessage("Channel id must be not empty.");
        }
    }
}
