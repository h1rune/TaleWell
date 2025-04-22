using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Queries.GetFanfics;
using AutoMapper;

namespace ArtService.WebApi.Models.WorkModels
{
    /// <summary>
    /// DTO для получения списка фанфиков.
    /// </summary>
    public class GetFanficsDto : IMapWith<GetFanficsQuery>
    {
        /// <summary>
        /// Идентификатор оригинального произведения, по которому ищутся фанфики.
        /// </summary>
        public Guid OriginalId { get; set; }

        /// <summary>
        /// Смещение для пагинации.
        /// </summary>
        public int? Offset { get; set; } = 0;

        /// <summary>
        /// Лимит количества возвращаемых записей.
        /// </summary>
        public int? Limit { get; set; } = 5;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetFanficsDto, GetFanficsQuery>()
                .ForMember(query => query.OriginalId, options => options.MapFrom(dto => dto.OriginalId))
                .ForMember(query => query.Offset, options => options.MapFrom(dto => dto.Offset))
                .ForMember(query => query.Limit, options => options.MapFrom(dto => dto.Limit));
        }
    }
}
