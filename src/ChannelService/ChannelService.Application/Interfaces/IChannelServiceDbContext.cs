using ChannelService.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Interfaces
{
    public interface IChannelServiceDbContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Reaction> Reactions { get; set; }
        DbSet<Channel> Channels { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
