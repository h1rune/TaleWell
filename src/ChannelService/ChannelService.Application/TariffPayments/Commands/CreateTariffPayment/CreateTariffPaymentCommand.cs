using MediatR;

namespace ChannelService.Application.TariffPayments.Commands.CreateTariffPayment
{
    public class CreateTariffPaymentCommand : IRequest<Unit>
    {
        public Guid ChannelId { get; set; }
    }
}
