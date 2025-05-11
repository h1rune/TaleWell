namespace ChannelService.Domain
{
    public class TariffPayment
    {
        public Guid Id { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndsAt { get; set; }

        public Channel? Channel { get; set; }
    }
}
