using ChannelService.Application.Common.Mappings;
using ChannelService.Application.Posts.Commands.UpdatePost;

namespace ChannelService.WebApi.Models.PostModels
{
    public class UpdatePostDto : IMapWith<UpdatePostCommand>
    {
        public Guid PostId { get; set; }
        public required string Text { get; set; }
    }
}
