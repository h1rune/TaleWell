using ChannelService.Application.Common.Mappings;
using ChannelService.Domain;

namespace ChannelService.Application.Channels.Queries.GetChannelByHandle
{
    public class ChannelVm : IMapWith<Channel>
    {
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public string? Description { get; set; }
    }
}