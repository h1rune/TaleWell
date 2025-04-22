using ArtService.Application.Common.Mappings;
using ArtService.Application.Reviews.Commands.UpdateReview;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.WebApi.Models.ReviewModels
{
    /// <summary>
    /// DTO для обновления существующего отзыва.
    /// </summary>
    public class UpdateReviewDto : IMapWith<UpdateReviewCommand>
    {
        /// <summary>
        /// Идентификатор отзыва, который нужно обновить.
        /// </summary>
        public Guid ReviewId { get; set; }

        /// <summary>
        /// Оценка отзыва, представлена как тип реакции.
        /// </summary>
        public ReactionType Mark { get; set; }

        /// <summary>
        /// Новый текст отзыва.
        /// </summary>
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
