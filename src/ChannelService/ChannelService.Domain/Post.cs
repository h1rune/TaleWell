namespace ChannelService.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public IList<Reaction> Reactions { get; set; } = [];
    }
}
