using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Comments.Queries.GetParagraphComments
{
    public class CommentLookupDto : IMapWith<Comment>
    {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public bool IsSpoiler { get; set; }
        public int? SpoilerChapterNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentLookupDto>();
        }
    }
}
