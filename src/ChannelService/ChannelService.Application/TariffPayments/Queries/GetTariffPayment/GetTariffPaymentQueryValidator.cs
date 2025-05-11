using FluentValidation;

namespace ChannelService.Application.TariffPayments.Queries.GetTariffPayment
{
    public class GetTariffPaymentQueryValidator : AbstractValidator<GetTariffPaymentQuery>
    {
        public GetTariffPaymentQueryValidator()
        {
            RuleFor(query => query.ChannelId)
                .NotEmpty();
        }
    }
}
