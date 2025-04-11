using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Comments.Queries.GetParagraph
{
    public class CommentVm : IMapWith<Comment>
    {
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
        public string Text { get; set; } = null!;
        public bool IsSpoiler { get; set; }
        public int? SpoilerChapterNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentVm>()
                .ForMember(commentDto => commentDto.ParagraphId, options => options.MapFrom(comment => comment.ParagraphId))
                .ForMember(commentDto => commentDto.Text, options => options.MapFrom(comment => comment.Text))
                .ForMember(commentDto => commentDto.IsSpoiler, options => options.MapFrom(comment => comment.IsSpoiler))
                .ForMember(commentDto => commentDto.SpoilerChapterNumber, options => options.MapFrom(comment => comment.SpoilerChapterNumber))
                .ForMember(commentDto => commentDto.CreatedAt, options => options.MapFrom(comment => comment.CreatedAt));
        }
    }
}
