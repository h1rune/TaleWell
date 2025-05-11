using ArtService.Application.Common.Mappings;
using ArtService.Application.Reactions.Commands.SwitchReaction;
using ArtService.Domain.Common;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.ReactionModels
{
    public class SwitchReactionDto : IMapWith<SwitchReactionCommand>
    {
        [SwaggerSchema("ID of paragraph to react")]
        public Guid ParagraphId { get; set; }

        [SwaggerSchema("Reaction to switch")]
        public ReactionType Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SwitchReactionDto, SwitchReactionCommand>();
        }
    }
}
