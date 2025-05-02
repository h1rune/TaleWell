using MediatR;

namespace ChannelService.Application.Reactions.Commands.DeleteReaction
{
    public class DeleteReactionCommand : IRequest<Unit>
    {
        public Guid ReactionId { get; set; }
        public Guid ActorId { get; set; }
    }
}
