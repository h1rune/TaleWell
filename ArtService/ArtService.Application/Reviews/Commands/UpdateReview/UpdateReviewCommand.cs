using ArtService.Domain;
using MediatR;

namespace ArtService.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<Unit>
    {
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }

        public ReactionType Mark { get; set; }
        public string Text { get; set; } = null!;
    }
}
