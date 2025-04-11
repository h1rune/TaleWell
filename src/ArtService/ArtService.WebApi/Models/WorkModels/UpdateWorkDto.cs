using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Commands.UpdateWork;
using AutoMapper;

namespace ArtService.WebApi.Models.WorkModels
{
    public class UpdateWorkDto : IMapWith<UpdateWorkCommand>
    {
        public Guid WorkId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public bool IsFanfic { get; set; }
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
