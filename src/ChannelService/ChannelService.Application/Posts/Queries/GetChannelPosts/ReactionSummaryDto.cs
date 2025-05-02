using ChannelService.Domain;

namespace ChannelService.Application.Posts.Queries.GetChannelPosts
{
    public class ReactionSummaryDto
    {
        public ReactionType ReactionType { get; set; }
        public int Count { get; set; }
        public Guid? CurrentUserReactionId { get; set; }
    }
}
