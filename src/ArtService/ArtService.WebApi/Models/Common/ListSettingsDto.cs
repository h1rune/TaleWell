using ArtService.Application.Comments.Queries.GetParagraphComments;
using ArtService.Application.Common.Mappings;
using ArtService.Application.Paragraphs.Queries.GetChapterParagraphs;
using ArtService.Application.Works.Queries.GetFanfics;
using ArtService.Application.Works.Queries.GetWorks;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.Common
{
    public class ListSettingsDto : IMapWith<GetFanficsQuery>, IMapWith<GetWorksQuery>, 
        IMapWith<GetChapterParagraphsQuery>, IMapWith<GetParagraphCommentsQuery>
    {
        [SwaggerSchema("Pagination offset for list with literary works.")]
        public int Offset { get; set; } = 0;

        [SwaggerSchema("Limit of literary works.")]
        public int Limit { get; set; } = 5;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListSettingsDto, GetFanficsQuery>();
            profile.CreateMap<ListSettingsDto, GetWorksQuery>();
            profile.CreateMap<ListSettingsDto, GetChapterParagraphsQuery>();
            profile.CreateMap<ListSettingsDto, GetParagraphCommentsQuery>();
        }
    }
}
