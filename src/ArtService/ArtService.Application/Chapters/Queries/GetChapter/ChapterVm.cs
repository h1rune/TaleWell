using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Chapters.Queries.GetChapter
{
    public class ChapterVm : IMapWith<Chapter>
    {
        public Guid VolumeId { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chapter, ChapterVm>()
                .ForMember(chapterDto => chapterDto.VolumeId, options => options.MapFrom(chapter => chapter.VolumeId))
                .ForMember(chapterDto => chapterDto.Order, options => options.MapFrom(chapter => chapter.Order))
                .ForMember(chapterDto => chapterDto.Title, options => options.MapFrom(chapter => chapter.Title))
                .ForMember(chapterDto => chapterDto.CreatedAt, options => options.MapFrom(chapter => chapter.CreatedAt));
        }
    }
}
