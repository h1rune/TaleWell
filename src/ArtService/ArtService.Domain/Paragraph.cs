namespace ArtService.Domain
{
    public class Paragraph
    {
        public Guid Id { get; set; }
        public Guid ChapterId { get; set; }
        public Chapter RelatedChapter { get; set; } = null!;

        public int Order { get; set; }
        public string S3Key { get; set; } = null!;

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
    }
}
