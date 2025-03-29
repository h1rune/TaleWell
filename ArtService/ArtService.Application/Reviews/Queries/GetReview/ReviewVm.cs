using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Reviews.Queries.GetReview
{
    public class ReviewVm : IMapWith<Review>
    {
        public Guid UserId { get; set; }
        public Guid WorkId { get; set; }
        public ReactionType Mark { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewVm>()
                .ForMember(reviewDto => reviewDto.WorkId, options => options.MapFrom(review => review.WorkId))
                .ForMember(reviewDto => reviewDto.UserId, options => options.MapFrom(review => review.UserId))
                .ForMember(reviewDto => reviewDto.Mark, options => options.MapFrom(review => review.Mark))
                .ForMember(reviewDto => reviewDto.Text, options => options.MapFrom(review => review.Text))
                .ForMember(reviewDto => reviewDto.CreatedAt, options => options.MapFrom(review => review.CreatedAt));
        }
    }
}
