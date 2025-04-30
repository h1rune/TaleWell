using AutoMapper;
using ChannelService.Application.Common.Exceptions;
using ChannelService.Application.Interfaces;
using ChannelService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class GetChannelByHandleCommandHandler(IChannelServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetChannelByHandleCommand, ChannelVm>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ChannelVm> Handle(GetChannelByHandleCommand request, CancellationToken cancellationToken)
        {
            var channelEntity = await _dbContext.Channels
                .FirstOrDefaultAsync(channel => channel.Handle == request.Handle, cancellationToken)
                ?? throw new NotFoundException(nameof(Channel), request.Handle);

            var channelVm = _mapper.Map<ChannelVm>(channelEntity);
            return channelVm;
        }
    }
}
