using ArtService.Application.Common.Mappings;
using ArtService.Application.Reviews.Commands.UpdateReview;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.WebApi.Models.ReviewModels
{
    public class UpdateReviewDto : IMapWith<UpdateReviewCommand>
    {
        public Guid ReviewId { get; set; }
        public ReactionType Mark { get; set; }
        public string Text { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateReviewDto, UpdateReviewCommand>()
                .ForMember(command => command.ReviewId, options => options.MapFrom(dto => dto.ReviewId))
                .ForMember(command => command.Mark, options => options.MapFrom(dto => dto.Mark))
                .ForMember(command => command.Text, options => options.MapFrom(dto => dto.Text));
        }
    }
}
