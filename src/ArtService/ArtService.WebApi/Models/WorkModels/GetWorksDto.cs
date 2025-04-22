using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Queries.GetWorks;
using AutoMapper;

namespace ArtService.WebApi.Models.WorkModels
{
    /// <summary>
    /// DTO для получения списка произведений.
    /// </summary>
    public class GetWorksDto : IMapWith<GetWorksQuery>
    {
        /// <summary>
        /// Смещение для пагинации.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Лимит количества возвращаемых записей.
        /// </summary>
        public int? Limit { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetWorksDto, GetWorksQuery>()
                .ForMember(query => query.Offset, options => options.MapFrom(dto => dto.Offset))
                .ForMember(query => query.Limit, options => options.MapFrom(dto => dto.Limit));
        }
    }
}
