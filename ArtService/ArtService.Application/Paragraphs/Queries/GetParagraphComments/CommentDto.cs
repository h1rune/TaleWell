using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Paragraphs.Queries.GetParagraphComments
{
    public class CommentDto : IMapWith<Comment>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentDto>()
                .ForMember(commentDto => commentDto.Id, options => options.MapFrom(comment => comment.Id))
                .ForMember(commentDto => commentDto.UserId, options => options.MapFrom(comment => comment.UserId))
                .ForMember(commentDto => commentDto.Text, options => options.MapFrom(comment => comment.Text))
                .ForMember(commentDto => commentDto.CreatedAt, options => options.MapFrom(comment => comment.CreatedAt));
        }
    }
}
