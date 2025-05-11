using ChannelService.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChannelService.Application.Interfaces
{
    public interface IChannelServiceDbContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Reaction> Reactions { get; set; }
        DbSet<Channel> Channels { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<PostView> PostViews { get; set; }
        DbSet<TariffPayment> TariffPayments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
