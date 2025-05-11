using AutoMapper;
using ChannelService.Application.Common.Mappings;
using ChannelService.Application.Reactions.Commands.CreateReaction;
using ChannelService.Domain;

namespace ChannelService.WebApi.Models.ReactionModels
{
    public class CreateReactionDto : IMapWith<CreateReactionCommand>
    {
        public Guid PostId { get; set; }
        public ReactionType ReactionType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateReactionDto, CreateReactionCommand>();
        }
    }
}
