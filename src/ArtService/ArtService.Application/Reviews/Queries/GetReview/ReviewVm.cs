using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using ArtService.Domain.Common;
using AutoMapper;

namespace ArtService.Application.Reviews.Queries.GetReview
{
    public class ReviewVm : IMapWith<Review>
    {
        public Guid UserId { get; set; }
        public Guid WorkId { get; set; }
        public ReactionType Mark { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewVm>();
        }
    }
}
