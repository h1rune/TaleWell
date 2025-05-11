using AutoMapper;
using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.TariffPayments.Queries.GetTariffPayment
{
    public class GetTariffPaymentQueryHandler(IChannelServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetTariffPaymentQuery, TariffPaymentVm>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<TariffPaymentVm> Handle(GetTariffPaymentQuery request, CancellationToken cancellationToken)
        {
            var paymentEntity = await _dbContext.TariffPayments
                .FirstOrDefaultAsync(payment => payment.ChannelId == request.ChannelId, cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.ChannelId);

            return _mapper.Map<TariffPaymentVm>(paymentEntity);
        }
    }
}
