using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.TariffPayments.Commands.DeleteTariffPayment
{
    public class DeleteTariffPaymentCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<DeleteTariffPaymentCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteTariffPaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentEntity = await _dbContext.TariffPayments
                .Include(payment => payment.Channel)
                .FirstOrDefaultAsync(payment => payment.ChannelId == request.ChannelId, cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.ChannelId);

            paymentEntity.Channel!.TariffPlan = TariffPlan.Free;
            _dbContext.TariffPayments.Remove(paymentEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
