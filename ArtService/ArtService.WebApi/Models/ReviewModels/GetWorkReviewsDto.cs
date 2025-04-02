using ArtService.Application.Common.Mappings;
using ArtService.Application.Reviews.Queries.GetWorkReviews;
using AutoMapper;

namespace ArtService.WebApi.Models.ReviewModels
{
    public class GetWorkReviewsDto : IMapWith<GetWorkReviewsQuery>
    {
        public Guid WorkId { get; set; }
        public int Offset { get; set; } = 0;
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
