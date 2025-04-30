namespace AuthService.Domain
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Token { get; set; }
        public required string AccountId { get; set; }
        public Account? Account { get; set; }

        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
