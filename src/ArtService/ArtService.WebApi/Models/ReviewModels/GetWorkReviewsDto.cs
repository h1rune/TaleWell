using ArtService.Application.Common.Mappings;
using ArtService.Application.Reviews.Queries.GetWorkReviews;
using AutoMapper;

namespace ArtService.WebApi.Models.ReviewModels
{
    /// <summary>
    /// DTO для получения списка отзывов для произведения.
    /// </summary>
    public class GetWorkReviewsDto : IMapWith<GetWorkReviewsQuery>
    {
        /// <summary>
        /// Идентификатор произведения, для которого нужно получить отзывы.
        /// </summary>
        public Guid WorkId { get; set; }

        /// <summary>
        /// Смещение для пагинации списка отзывов.
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Лимит количества возвращаемых отзывов.
        /// </summary>
        public int Limit { get; set; } = 5;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetWorkReviewsDto, GetWorkReviewsQuery>()
                .ForMember(query => query.WorkId, options => options.MapFrom(dto => dto.WorkId))
                .ForMember(query => query.Offset, options => options.MapFrom(dto => dto.Offset))
                .ForMember(query => query.Limit, options => options.MapFrom(dto => dto.Limit));
        }
    }
}
