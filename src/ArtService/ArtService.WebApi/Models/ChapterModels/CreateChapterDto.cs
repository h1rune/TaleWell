using ArtService.Application.Chapters.Commands.CreateChapter;
using ArtService.Application.Common.Mappings;
using AutoMapper;

namespace ArtService.WebApi.Models.ChapterModels
{
    /// <summary>
    /// DTO для создания новой главы.
    /// </summary>
    public class CreateChapterDto : IMapWith<CreateChapterCommand>
    {
        /// <summary>
        /// Идентификатор тома, к которому принадлежит глава.
        /// </summary>
        public Guid VolumeId { get; set; }

        /// <summary>
        /// Порядковый номер главы в томе.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Название главы (опционально).
        /// </summary>
        public string? Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateChapterDto, CreateChapterCommand>()
                .ForMember(command => command.VolumeId, options => options.MapFrom(dto => dto.VolumeId))
                .ForMember(command => command.Order, options => options.MapFrom(dto => dto.Order))
                .ForMember(command => command.Title, options => options.MapFrom(dto => dto.Title));
        }
    }
}
