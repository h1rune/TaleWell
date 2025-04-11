using ArtService.Domain;
using MediatR;

namespace ArtService.Application.Reactions.Commands.SwitchReaction
{
    public class SwitchReactionCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
        public ReactionType Type { get; set; }
    }
}
