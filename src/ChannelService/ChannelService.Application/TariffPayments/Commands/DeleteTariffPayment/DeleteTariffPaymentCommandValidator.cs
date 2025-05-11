using FluentValidation;

namespace ChannelService.Application.TariffPayments.Commands.DeleteTariffPayment
{
    public class DeleteTariffPaymentCommandValidator : AbstractValidator<DeleteTariffPaymentCommand>
    {
        public DeleteTariffPaymentCommandValidator()
        {
            RuleFor(command => command.ChannelId)
                .NotEmpty();
        }
    }
}
