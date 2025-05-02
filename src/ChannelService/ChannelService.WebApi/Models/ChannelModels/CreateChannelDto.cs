using ChannelService.Application.Channels.Commands.CreateChannel;
using ChannelService.Application.Common.Mappings;

namespace ChannelService.WebApi.Models.ChannelModels
{
    public class CreateChannelDto : IMapWith<CreateChannelCommand>
    {
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public string? Description { get; set; }
    }
}
