using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;

namespace ArtService.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<Guid>, IHasWorkId
    {
        public Guid UserId { get; set; }
        public Guid WorkId { get; set; }
        public ReactionType Mark { get; set; }
        public string Text { get; set; } = null!;
    }
}
