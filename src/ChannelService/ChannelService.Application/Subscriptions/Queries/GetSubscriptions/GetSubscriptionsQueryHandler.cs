using AutoMapper;
using ChannelService.Application.Interfaces;
using MediatR;

namespace ChannelService.Application.Subscriptions.Queries.GetSubscriptions
{
    public class GetSubscriptionsQueryHandler(IChannelServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetSubscriptionsQuery, SubscriptionsVm>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public Task<SubscriptionsVm> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
