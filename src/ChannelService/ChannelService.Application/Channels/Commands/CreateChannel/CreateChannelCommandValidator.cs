using FluentValidation;

namespace ChannelService.Application.Channels.Commands.CreateChannel
{
    public class CreateChannelCommandValidator : AbstractValidator<CreateChannelCommand>
    {
        public CreateChannelCommandValidator()
        {
            RuleFor(command => command.ChannelId)
                .NotEmpty().WithMessage("Channel id must not be empty.");
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Title must not be empty.");
            RuleFor(command => command.Handle)
                .NotEmpty().WithMessage("Handle must not be empty.");
        }
    }
}
