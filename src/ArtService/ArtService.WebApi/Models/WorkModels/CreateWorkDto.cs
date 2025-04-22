using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Commands.CreateWork;
using AutoMapper;

namespace ArtService.WebApi.Models.WorkModels
{
    /// <summary>
    /// DTO для создания нового литературного произведения.
    /// </summary>
    public class CreateWorkDto : IMapWith<CreateWorkCommand>
    {
        /// <summary>
        /// Название произведения.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Описание произведения.
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
            profile.CreateMap<CreateWorkDto,  CreateWorkCommand>()
                .ForMember(command => command.Title, options => options.MapFrom(dto => dto.Title))
                .ForMember(command => command.Description, options => options.MapFrom(dto => dto.Description))
                .ForMember(command => command.IsFanfic, options => options.MapFrom(dto => dto.IsFanfic))
                .ForMember(command => command.OriginalWorkId, options => options.MapFrom(dto => dto.OriginalWorkId));
        }
    }
}
