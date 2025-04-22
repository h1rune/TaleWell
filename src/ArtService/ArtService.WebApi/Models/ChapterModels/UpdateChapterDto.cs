using ArtService.Application.Chapters.Commands.UpdateChapter;
using AutoMapper;

namespace ArtService.WebApi.Models.ChapterModels
{
    /// <summary>
    /// DTO для обновления существующей главы.
    /// </summary>
    public class UpdateChapterDto
    {
        /// <summary>
        /// Идентификатор главы.
        /// </summary>
        public Guid ChapterId { get; set; }

        /// <summary>
        /// Новый порядковый номер главы.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Обновленное название главы (опционально).
        /// </summary>
        public string? Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateChapterDto, UpdateChapterCommand>()
                .ForMember(command => command.ChapterId, options => options.MapFrom(dto => dto.ChapterId))
                .ForMember(command => command.Order, options => options.MapFrom(dto => dto.Order))
                .ForMember(command => command.Title, options => options.MapFrom(dto => dto.Title));
        }
    }
}
