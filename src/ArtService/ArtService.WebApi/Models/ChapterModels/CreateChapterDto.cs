using ArtService.Application.Chapters.Commands.CreateChapter;
using ArtService.Application.Common.Mappings;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.ChapterModels
{
    public class CreateChapterDto : IMapWith<CreateChapterCommand>
    {
        [SwaggerSchema("ID of new chapter's volume")]
        public Guid VolumeId { get; set; }

        [SwaggerSchema("Order of new chapter in volume")]
        public int Order { get; set; }

        [SwaggerSchema("Title of new chapter")]
        public string? Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateChapterDto, CreateChapterCommand>();
        }
    }
}
