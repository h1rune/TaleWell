using ArtService.Application.Common.Mappings;
using ArtService.Application.Reviews.Commands.CreateReview;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.WebApi.Models.ReviewModels
{
    public class CreateReviewDto : IMapWith<CreateReviewCommand>
    {
        public Guid WorkId { get; set; }
        public ReactionType Mark { get; set; }
        public string Text { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateReviewDto, CreateReviewCommand>()
                .ForMember(command => command.WorkId, options => options.MapFrom(dto => dto.WorkId))
                .ForMember(command => command.Mark, options => options.MapFrom(dto => dto.Mark))
                .ForMember(command => command.Text, options => options.MapFrom(dto => dto.Text));
        }
    }
}
