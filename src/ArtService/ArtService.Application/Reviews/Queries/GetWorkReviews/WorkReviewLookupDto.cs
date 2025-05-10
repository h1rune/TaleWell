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
        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, WorkReviewLookupDto>()
                .ForMember(reviewDto => reviewDto.Id, options => options.MapFrom(review => review.Id))
                .ForMember(reviewDto => reviewDto.UserId, options => options.MapFrom(review => review.OwnerId))
                .ForMember(reviewDto => reviewDto.Mark, options => options.MapFrom(review => review.Mark))
                .ForMember(reviewDto => reviewDto.Text, options => options.MapFrom(review => review.Text))
                .ForMember(reviewDto => reviewDto.CreatedAt, options => options.MapFrom(review => review.CreatedAt));
        }
    }
}
