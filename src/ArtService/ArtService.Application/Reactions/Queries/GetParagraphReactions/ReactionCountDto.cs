﻿using ArtService.Domain.Common;

namespace ArtService.Application.Reactions.Queries.GetParagraphReactions
{
    public class ReactionCountDto
    {
        public ReactionType Type { get; set; }
        public int Count { get; set; }
        public bool IsUserPut { get; set; }
    }
}
