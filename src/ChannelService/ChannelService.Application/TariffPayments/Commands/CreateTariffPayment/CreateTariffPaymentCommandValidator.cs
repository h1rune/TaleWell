using FluentValidation;

namespace ChannelService.Application.TariffPayments.Commands.CreateTariffPayment
{
    public class CreateTariffPaymentCommandValidator : AbstractValidator<CreateTariffPaymentCommand>
    {
        public CreateTariffPaymentCommandValidator()
        {
            RuleFor(command => command.ChannelId)
                .NotEmpty();
        }
    }
}
