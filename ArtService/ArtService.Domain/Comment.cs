namespace ArtService.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
        public Paragraph RelatedParagraph { get; set; } = null!;

        public string Text { get; set; } = null!;
        public bool IsSpoiler { get; set; }
        public int? SpoilerChapterNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
