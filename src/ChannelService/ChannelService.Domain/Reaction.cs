namespace ChannelService.Domain
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public Guid ActorId { get; set; }
        public Guid PostId { get; set; }
        public ReactionType ReactionType { get; set; }
        public DateTime PutAt { get; set; }

        public Post? Post { get; set; }
        public Channel? Actor { get; set; }
    }
}
