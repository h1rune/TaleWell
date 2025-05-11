using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.TariffPayments.Commands.CreateTariffPayment
{
    public class CreateTariffPaymentCommandHandler(IChannelServiceDbContext dbContext)
        : IRequestHandler<CreateTariffPaymentCommand, Unit>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(CreateTariffPaymentCommand request, CancellationToken cancellationToken)
        {
            var channelEntity = await _dbContext.Channels
                .FirstOrDefaultAsync(channel => channel.Id == request.ChannelId, cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.ChannelId);

            var payment = new TariffPayment
            {
                Id = Guid.NewGuid(),
                ChannelId = channelEntity.Id,
                StartedAt = DateTime.UtcNow,
                EndsAt = DateTime.UtcNow.AddMonths(1),
            };

            channelEntity.TariffPlan = TariffPlan.Premium;

            await _dbContext.TariffPayments.AddAsync(payment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
