using ChannelService.Application.Channels.Commands.UpdateChannel;
using ChannelService.Application.Common.Mappings;

namespace ChannelService.WebApi.Models.ChannelModels
{
    public class UpdateChannelDto : IMapWith<UpdateChannelCommand>
    {
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public string? Description { get; set; }
    }
}
