﻿using ArtService.Domain.Common;
using MediatR;

namespace ArtService.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public required string OwnerHandle { get; set; }
        public Guid WorkId { get; set; }
        public ReactionType Mark { get; set; }
        public required string Text { get; set; }
    }
}
