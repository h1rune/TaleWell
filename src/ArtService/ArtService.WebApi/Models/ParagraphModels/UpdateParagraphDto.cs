using ArtService.Application.Common.Mappings;
using ArtService.Application.Paragraphs.Commands.UpdateParagraph;
using AutoMapper;

namespace ArtService.WebApi.Models.ParagraphModels
{
    /// <summary>
    /// DTO для обновления существующего параграфа.
    /// </summary>
    public class UpdateParagraphDto : IMapWith<UpdateParagraphCommand>
    {
        /// <summary>
        /// Идентификатор параграфа.
        /// </summary>
        public Guid ParagraphId { get; set; }

        /// <summary>
        /// Новый порядок следования параграфа.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Обновлённый текст параграфа.
        /// </summary>
        public string Text { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateParagraphDto, UpdateParagraphCommand>()
                .ForMember(command => command.ParagraphId, options => options.MapFrom(dto => dto.ParagraphId))
                .ForMember(command => command.Order, options => options.MapFrom(dto => dto.Order))
                .ForMember(command => command.Text, options => options.MapFrom(dto => dto.Text));
        }
    }
}
