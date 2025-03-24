namespace ArtService.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
        public required Paragraph RelatedParagraph { get; set; }
        
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
