namespace ChannelService.Domain
{
    public class PostView
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid ViewerId { get; set; }
        public DateTime ViewedAt { get; set; }

        public Post? ViewingPost { get; set; }
        public Channel? Viewer { get; set; }
    }
}
