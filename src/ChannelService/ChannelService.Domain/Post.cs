﻿namespace ChannelService.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid ChannelId { get; set; }
        public Channel? Channel { get; set; }

        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public IList<Reaction> Reactions { get; set; } = [];
        public IList<PostView> PostViews { get; set; } = [];
    }
}
