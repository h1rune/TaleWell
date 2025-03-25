namespace ArtService.Domain
{
    public class Paragraph
    {
        public Guid Id { get; set; }
        public Guid ChapterId { get; set; }
        public Chapter RelatedChapter { get; set; } = null!;

        public uint Order { get; set; }
        public required string S3Url { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
    }
}
