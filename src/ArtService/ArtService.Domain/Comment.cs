using ArtService.Domain.Common;

namespace ArtService.Domain
{
    public class Comment : IDomainEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public required string OwnerHandle { get; set; }
        public Guid ParagraphId { get; set; }
        public Paragraph RelatedParagraph { get; set; } = null!;

        public required string Text { get; set; }
        public bool IsSpoiler { get; set; }
        public Guid? SpoilerChapterId { get; set; }
        public Chapter? SpoilerChapter { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
