using MediatR;

namespace ChannelService.Application.TariffPayments.Commands.DeleteTariffPayment
{
    public class DeleteTariffPaymentCommand : IRequest<Unit>
    {
        public Guid ChannelId { get; set; }
    }
}
