using ChannelService.Domain;
using MediatR;

namespace ChannelService.Application.Reactions.Commands.CreateReaction
{
    public class CreateReactionCommand : IRequest<Guid>
    {
        public Guid ActorId { get; set; }
        public Guid PostId { get; set; }
        public ReactionType ReactionType { get; set; }
    }
}
