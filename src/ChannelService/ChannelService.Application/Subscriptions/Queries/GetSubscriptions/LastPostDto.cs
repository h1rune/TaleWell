namespace ChannelService.Application.Subscriptions.Queries.GetSubscriptions
{
    public class LastPostDto
    {
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
