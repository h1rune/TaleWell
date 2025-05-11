using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using ArtService.Domain.Common;
using AutoMapper;

namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class WorkReviewLookupDto : IMapWith<Review>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ReactionType Mark { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, WorkReviewLookupDto>();
        }
    }
}
