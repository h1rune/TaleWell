using AutoMapper;
using ChannelService.Application.Common.Mappings;
using ChannelService.Domain;

namespace ChannelService.Application.Posts.Queries.GetChannelPosts
{
    public class PostLookupDto : IMapWith<Post>
    {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public IList<Reaction> Reactions { get; set; } = [];

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostLookupDto>()
                .ForMember(dto => dto.Id, options => options.MapFrom(post => post.Id))
                .ForMember(dto => dto.Text, options => options.MapFrom(post => post.Text))
                .ForMember(dto => dto.CreatedAt, options => options.MapFrom(post => post.CreatedAt))
                .ForMember(dto => dto.EditedAt, options => options.MapFrom(post => post.EditedAt))
                .ForMember(dto => dto.Reactions, options => options.MapFrom(post => post.Reactions));
        }
    }
}
