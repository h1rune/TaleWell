namespace ChannelService.Domain
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public Guid FollowedId { get; set; }
        public Guid FollowerId { get; set; }
        public DateTime SubscribedAt { get; set; }
        public Guid LastSeenPostId { get; set; }

        public Channel? Followed { get; set; }
        public Channel? Follower { get; set; }
        public Post? LastSeenPost { get; set; }
    }
}
