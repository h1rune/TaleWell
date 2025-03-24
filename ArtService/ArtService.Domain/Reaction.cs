namespace ArtService.Domain
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public Guid ParagraphId { get; set; }
        public Guid UserId { get; set; }
        public ReactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
