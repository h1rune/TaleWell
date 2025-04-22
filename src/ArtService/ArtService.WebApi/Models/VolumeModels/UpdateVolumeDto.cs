using ArtService.Application.Common.Mappings;
using ArtService.Application.Volumes.Commands.UpdateVolume;
using AutoMapper;

namespace ArtService.WebApi.Models.VolumeModels
{
    /// <summary>
    /// DTO для обновления информации о томе.
    /// </summary>
    public class UpdateVolumeDto : IMapWith<UpdateVolumeCommand>
    {
        /// <summary>
        /// Идентификатор тома.
        /// </summary>
        public Guid VolumeId { get; set; }

        /// <summary>
        /// Новый порядковый номер.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Новое название (опционально).
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Новая обложка (опционально).
        /// </summary>
        public IFormFile? CoverFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateVolumeDto, UpdateVolumeCommand>()
                .ForMember(command => command.VolumeId, options => options.MapFrom(dto => dto.VolumeId))
                .ForMember(command => command.Order, options => options.MapFrom(dto => dto.Order))
                .ForMember(command => command.Title, options => options.MapFrom(dto => dto.Title))
                .ForMember(command => command.CoverFile, options => options.MapFrom(dto => dto.CoverFile));
        }
    }
}
