namespace ChannelService.Domain
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public ReactionType ReactionType { get; set; }
        public DateTime PutAt { get; set; }
    }
}
