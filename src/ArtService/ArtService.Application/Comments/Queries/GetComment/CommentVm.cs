using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Comments.Queries.GetParagraph
{
    public class CommentVm : IMapWith<Comment>
    {
        public required string OwnerHandle { get; set; }
        public Guid ParagraphId { get; set; }
        public required string Text { get; set; }
        public bool IsSpoiler { get; set; }
        public int? SpoilerChapterNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentVm>();
        }
    }
}
