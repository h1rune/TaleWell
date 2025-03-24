namespace ArtService.Domain
{
    public class Paragraph
    {
        public Guid Id { get; set; }
        public Guid ChapterId { get; set; }
        public required Chapter RelatedChapter { get; set; }

        public uint Order { get; set; }
        public required string S3Url { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
    }
}
