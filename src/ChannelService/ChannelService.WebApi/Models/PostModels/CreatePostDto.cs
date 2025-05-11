using AutoMapper;
using ChannelService.Application.Common.Mappings;
using ChannelService.Application.Posts.Commands.CreatePost;

namespace ChannelService.WebApi.Models.PostModels
{
    public class CreatePostDto : IMapWith<CreatePostCommand>
    {
        public required string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostDto, CreatePostCommand>();
        }
    }
}
