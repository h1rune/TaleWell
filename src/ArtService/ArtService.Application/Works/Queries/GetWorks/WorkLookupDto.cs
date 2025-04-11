using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Works.Queries.GetWorks
{
    public class WorkLookupDto : IMapWith<Work>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Work, WorkLookupDto>()
                .ForMember(fanficDto => fanficDto.Id, options => options.MapFrom(work => work.Id))
                .ForMember(fanficDto => fanficDto.AuthorId, options => options.MapFrom(work => work.AuthorId))
                .ForMember(fanficDto => fanficDto.Title, options => options.MapFrom(work => work.Title))
                .ForMember(fanficDto => fanficDto.Description, options => options.MapFrom(work => work.Description))
                .ForMember(fanficDto => fanficDto.IsFanfic, options => options.MapFrom(work => work.IsFanfic))
                .ForMember(fanficDto => fanficDto.OriginalWorkId, options => options.MapFrom(work => work.OriginalWorkId))
                .ForMember(fanficDto => fanficDto.CreatedAt, options => options.MapFrom(work => work.CreatedAt));
        }
    }
}
