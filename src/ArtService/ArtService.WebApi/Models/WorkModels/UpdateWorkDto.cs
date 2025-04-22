using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Commands.UpdateWork;
using AutoMapper;

namespace ArtService.WebApi.Models.WorkModels
{
    /// <summary>
    /// DTO для обновления существующего литературного произведения.
    /// </summary>
    public class UpdateWorkDto : IMapWith<UpdateWorkCommand>
    {
        /// <summary>
        /// Идентификатор произведения, которое необходимо обновить.
        /// </summary>
        public Guid WorkId { get; set; }

        /// <summary>
        /// Новое название произведения.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Новое описание произведения.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Указывает, является ли произведение фанфиком.
        /// </summary>
        public bool IsFanfic { get; set; }

        /// <summary>
        /// Идентификатор оригинального произведения, если это фанфик.
        /// </summary>
        public Guid? OriginalWorkId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateWorkDto, UpdateWorkCommand>()
                .ForMember(command => command.WorkId, options => options.MapFrom(dto => dto.WorkId))
                .ForMember(command => command.Title, options => options.MapFrom(dto => dto.Title))
                .ForMember(command => command.Description, options => options.MapFrom(dto => dto.Description))
                .ForMember(command => command.IsFanfic, options => options.MapFrom(dto => dto.IsFanfic))
                .ForMember(command => command.OriginalWorkId, options => options.MapFrom(dto => dto.OriginalWorkId));
        }
    }
}
