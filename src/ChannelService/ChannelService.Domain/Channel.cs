namespace ChannelService.Domain
{
    public class Channel
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Handle { get; set; }
        public string? Description { get; set; }

        public IList<Post> Posts { get; set; } = [];
        public IList<Subscription> Followers { get; set; } = [];
        public IList<Subscription> Following { get; set; } = [];
    }
}
