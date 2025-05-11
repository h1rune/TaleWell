using AutoMapper;
using ChannelService.Application.Common.Mappings;
using ChannelService.Domain;

namespace ChannelService.Application.TariffPayments.Queries.GetTariffPayment
{
    public class TariffPaymentVm : IMapWith<TariffPayment>
    {
        public DateTime StartedAt { get; set; }
        public DateTime EndsAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TariffPayment, TariffPaymentVm>();
        }
    }
}
