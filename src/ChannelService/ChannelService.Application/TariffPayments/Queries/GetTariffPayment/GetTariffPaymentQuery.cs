using MediatR;

namespace ChannelService.Application.TariffPayments.Queries.GetTariffPayment
{
    public class GetTariffPaymentQuery : IRequest<TariffPaymentVm>
    {
        public Guid ChannelId { get; set; }
    }
}
