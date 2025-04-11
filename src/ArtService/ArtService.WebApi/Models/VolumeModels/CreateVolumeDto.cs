using ArtService.Application.Common.Mappings;
using ArtService.Application.Volumes.Commands.CreateVolume;
using AutoMapper;

namespace ArtService.WebApi.Models.VolumeModels
{
    public class CreateVolumeDto : IMapWith<CreateVolumeCommand>
    {
        public Guid WorkId { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public IFormFile? CoverFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateVolumeDto, CreateVolumeCommand>()
                .ForMember(command => command.WorkId, options => options.MapFrom(dto => dto.WorkId))
                .ForMember(command => command.Order, options => options.MapFrom(dto => dto.Order))
                .ForMember(command => command.Title, options => options.MapFrom(dto => dto.Title))
                .ForMember(command => command.CoverFile, options => options.MapFrom(dto => dto.CoverFile));
        }
    }
}
