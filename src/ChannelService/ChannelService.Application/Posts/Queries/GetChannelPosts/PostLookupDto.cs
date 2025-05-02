namespace ChannelService.Application.Posts.Queries.GetChannelPosts
{
    public class PostLookupDto
    {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public IList<ReactionSummaryDto> Reactions { get; set; } = [];
    }
}
