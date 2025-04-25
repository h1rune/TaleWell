using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChannelService.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Posts.Queries.GetChannelPosts
{
    public class GetChannelPostsQueryHandler(IChannelServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetChannelPostsQuery, ChannelPostsVm>
    {
        private readonly IChannelServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ChannelPostsVm> Handle(GetChannelPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _dbContext.Posts
                .Include(post => post.Reactions)
                .Where(post => post.ChannelId == request.ChannelId)
                .OrderBy(post => post.CreatedAt)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ProjectTo<PostLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ChannelPostsVm { Posts = posts };
        }
    }
}
