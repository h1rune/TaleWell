using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Works.Queries.GetWork
{
    public class WorkVm : IMapWith<Work>
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Work, WorkVm>()
                .ForMember(workDto => workDto.AuthorId, options => options.MapFrom(work => work.AuthorId))
                .ForMember(workDto => workDto.Title, options => options.MapFrom(work => work.Title))
                .ForMember(workDto => workDto.Description, options => options.MapFrom(work => work.Description))
                .ForMember(workDto => workDto.IsFanfic, options => options.MapFrom(work => work.IsFanfic))
                .ForMember(workDto => workDto.OriginalWorkId, options => options.MapFrom(work => work.OriginalWorkId))
                .ForMember(workDto => workDto.CreatedAt, options => options.MapFrom(work => work.CreatedAt));
        }
    }
}
