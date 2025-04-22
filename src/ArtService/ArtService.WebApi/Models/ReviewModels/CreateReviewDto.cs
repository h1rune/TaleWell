using ArtService.Application.Common.Mappings;
using ArtService.Application.Reviews.Commands.CreateReview;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.WebApi.Models.ReviewModels
{
    /// <summary>
    /// DTO для создания нового отзыва о произведении.
    /// </summary>
    public class CreateReviewDto : IMapWith<CreateReviewCommand>
    {
        /// <summary>
        /// Идентификатор произведения, к которому относится отзыв.
        /// </summary>
        public Guid WorkId { get; set; }

        /// <summary>
        /// Оценка отзыва, представлена как тип реакции.
        /// </summary>
        public ReactionType Mark { get; set; }

        /// <summary>
        /// Текст отзыва.
        /// </summary>
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
