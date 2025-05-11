using ArtService.Application.Common.Mappings;
using ArtService.Application.Volumes.Commands.CreateVolume;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.VolumeModels
{
    public class CreateVolumeDto : IMapWith<CreateVolumeCommand>
    {
        [SwaggerSchema("ID of volume's literary work")]
        public Guid WorkId { get; set; }

        [SwaggerSchema("New order of volume in literary work")]
        public int Order { get; set; }

        [SwaggerSchema("New title of volume")]
        public required string Title { get; set; }

        [SwaggerSchema("New cover of volume")]
        public IFormFile? CoverFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateVolumeDto, CreateVolumeCommand>();
        }
    }
}
