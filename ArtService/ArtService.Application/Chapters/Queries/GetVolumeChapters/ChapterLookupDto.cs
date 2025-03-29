using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Chapters.Queries.GetVolumeChapters
{
    public class ChapterLookupDto : IMapWith<Chapter>
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chapter, ChapterLookupDto>()
                .ForMember(chapterDto => chapterDto.Id, options => options.MapFrom(chapter => chapter.Id))
                .ForMember(chapterDto => chapterDto.Order, options => options.MapFrom(chapter => chapter.Order))
                .ForMember(chapterDto => chapterDto.Title, options => options.MapFrom(chapter => chapter.Title))
                .ForMember(chapterDto => chapterDto.CreatedAt, options => options.MapFrom(chapter => chapter.CreatedAt));
        }
    }
}
