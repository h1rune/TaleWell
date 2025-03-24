namespace ArtService.Domain
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
        public required Paragraph RelatedParagraph { get; set; }

        public ReactionType Type { get; set; }
        public DateTime PutAt { get; set; }
    }
}
