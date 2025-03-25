using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class ReviewLookupDto : IMapWith<Review>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ReactionType Mark { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewLookupDto>()
                .ForMember(reviewDto => reviewDto.Id, options => options.MapFrom(review => review.Id))
                .ForMember(reviewDto => reviewDto.UserId, options => options.MapFrom(review => review.UserId))
                .ForMember(reviewDto => reviewDto.Mark, options => options.MapFrom(review => review.Mark))
                .ForMember(reviewDto => reviewDto.Text, options => options.MapFrom(review => review.Text))
                .ForMember(reviewDto => reviewDto.CreatedAt, options => options.MapFrom(review => review.CreatedAt));
        }
    }
}
