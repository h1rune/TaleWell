using FluentValidation;

namespace ChannelService.Application.Channels.Commands.UpdateChannel
{
    public class UpdateChannelCommandValidator : AbstractValidator<UpdateChannelCommand>
    {
        public UpdateChannelCommandValidator()
        {
            RuleFor(command => command.ChannelId)
                .NotEmpty().WithMessage("Channel id must be not empty.");
            RuleFor(command => command.Handle)
                .NotEmpty().WithMessage("Handle must be not empty.");
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Title must be not empty.");
        }
    }
}
