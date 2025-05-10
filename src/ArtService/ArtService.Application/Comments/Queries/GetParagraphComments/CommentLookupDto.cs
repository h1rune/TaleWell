using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Comments.Queries.GetParagraphComments
{
    public class CommentLookupDto : IMapWith<Comment>
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public bool IsSpoiler { get; set; }
        public int? SpoilerChapterNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentLookupDto>()
                .ForMember(commentDto => commentDto.Id, options => options.MapFrom(comment => comment.Id))
                .ForMember(commentDto => commentDto.Text, options => options.MapFrom(comment => comment.Text))
                .ForMember(commentDto => commentDto.IsSpoiler, options => options.MapFrom(comment => comment.IsSpoiler))
                .ForMember(commentDto => commentDto.SpoilerChapterNumber, options => options.MapFrom(comment => comment.SpoilerChapterId))
                .ForMember(commentDto => commentDto.CreatedAt, options => options.MapFrom(comment => comment.CreatedAt));
        }
    }
}
