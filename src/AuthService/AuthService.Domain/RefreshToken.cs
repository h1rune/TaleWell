﻿namespace AuthService.Domain
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Token { get; set; } = null!;
        public string AccountId { get; set; } = null!;
        public Account Account { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
