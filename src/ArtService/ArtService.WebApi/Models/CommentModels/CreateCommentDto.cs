using ArtService.Application.Comments.Commands.CreateComment;
using ArtService.Application.Common.Mappings;
using AutoMapper;

namespace ArtService.WebApi.Models.CommentModels
{
    /// <summary>
    /// DTO для создания комментария к параграфу.
    /// </summary>
    public class CreateCommentDto : IMapWith<CreateCommentCommand>
    {
        /// <summary>
        /// Идентификатор параграфа, к которому оставляется комментарий.
        /// </summary>
        public Guid ParagraphId { get; set; }

        /// <summary>
        /// Текст комментария.
        /// </summary>
        public string Text { get; set; } = null!;

        /// <summary>
        /// Признак того, содержит ли комментарий спойлер.
        /// </summary>
        public bool IsSpoiler { get; set; }

        /// <summary>
        /// Номер главы, которую спойлерит комментарий (если есть).
        /// </summary>
        public int? SpoilerChapterNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommentDto, CreateCommentCommand>()
                .ForMember(command => command.ParagraphId, options => options.MapFrom(dto => dto.ParagraphId))
                .ForMember(command => command.Text, options => options.MapFrom(dto => dto.Text))
                .ForMember(command => command.IsSpoiler, options => options.MapFrom(dto => dto.IsSpoiler))
                .ForMember(command => command.SpoilerChapterNumber, options => options.MapFrom(dto => dto.SpoilerChapterNumber));
        }
    }
}
