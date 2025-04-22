using ArtService.Application.Comments.Commands.UpdateComment;
using ArtService.Application.Common.Mappings;
using AutoMapper;

namespace ArtService.WebApi.Models.CommentModels
{
    /// <summary>
    /// DTO для обновления комментария.
    /// </summary>
    public class UpdateCommentDto : IMapWith<UpdateCommentCommand>
    {
        /// <summary>
        /// Идентификатор комментария.
        /// </summary>
        public Guid CommentId { get; set; }

        /// <summary>
        /// Обновлённый текст комментария.
        /// </summary>
        public string Text { get; set; } = null!;

        /// <summary>
        /// Признак того, содержит ли комментарий спойлер.
        /// </summary>
        public bool IsSpoiler { get; set; }

        /// <summary>
        /// Обновлённый номер главы, которую спойлерит комментарий (если есть).
        /// </summary>
        public int? SpoilerChapterNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCommentDto, UpdateCommentCommand>()
                .ForMember(command => command.CommentId, options => options.MapFrom(dto => dto.CommentId))
                .ForMember(command => command.Text, options => options.MapFrom(dto => dto.Text))
                .ForMember(command => command.IsSpoiler, options => options.MapFrom(dto => dto.IsSpoiler))
                .ForMember(command => command.SpoilerChapterNumber, options => options.MapFrom(dto => dto.SpoilerChapterNumber));
        }
    }
}
