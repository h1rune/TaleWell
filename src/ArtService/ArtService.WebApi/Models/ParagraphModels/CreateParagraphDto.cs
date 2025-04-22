using ArtService.Application.Common.Mappings;
using ArtService.Application.Paragraphs.Commands.CreateParagraph;
using AutoMapper;

namespace ArtService.WebApi.Models.ParagraphModels
{
    /// <summary>
    /// DTO для создания параграфа в главе.
    /// </summary>
    public class CreateParagraphDto : IMapWith<CreateParagraphCommand>
    {
        /// <summary>
        /// Идентификатор главы, в которую добавляется параграф.
        /// </summary>
        public Guid ChapterId { get; set; }

        /// <summary>
        /// Порядок следования параграфа в главе.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Текст параграфа.
        /// </summary>
        public string Text { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateParagraphDto, CreateParagraphCommand>()
                .ForMember(command => command.ChapterId, options => options.MapFrom(dto => dto.ChapterId))
                .ForMember(command => command.Order, options => options.MapFrom(dto => dto.Order))
                .ForMember(command => command.Text, options => options.MapFrom(dto => dto.Text));
        }
    }
}
