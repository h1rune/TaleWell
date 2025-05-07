using ArtService.Application.Common.Mappings;
using ArtService.Application.Volumes.Commands.UpdateVolume;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.VolumeModels
{
    public class UpdateVolumeDto : IMapWith<UpdateVolumeCommand>
    {
        [SwaggerSchema("New order of volume in literary work")]
        public int Order { get; set; }

        [SwaggerSchema("New title of volume")]
        public required string Title { get; set; }

        [SwaggerSchema("New cover of volume")]
        public IFormFile? CoverFile { get; set; }
    }
}
