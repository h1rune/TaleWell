using ArtService.Application.Common.Mappings;
using ArtService.Application.Reactions.Commands.SwitchReaction;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.WebApi.Models.ReactionModels
{
    /// <summary>
    /// DTO для переключения реакции на параграф.
    /// </summary>
    public class SwitchReactionDto : IMapWith<SwitchReactionCommand>
    {
        /// <summary>
        /// Идентификатор параграфа, к которому относится реакция.
        /// </summary>
        public Guid ParagraphId { get; set; }

        /// <summary>
        /// Тип реакции (например, Like, Dislike и т.д.).
        /// </summary>
        public ReactionType Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SwitchReactionDto, SwitchReactionCommand>()
                .ForMember(command => command.ParagraphId, options => options.MapFrom(dto => dto.ParagraphId))
                .ForMember(command => command.Type, options => options.MapFrom(dto => dto.Type));
        }
    }
}
