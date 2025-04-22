using ArtService.Application.Comments.Commands.CreateComment;
using ArtService.Application.Comments.Commands.DeleteComment;
using ArtService.Application.Comments.Commands.UpdateComment;
using ArtService.Application.Comments.Queries.GetComment;
using ArtService.Application.Comments.Queries.GetParagraph;
using ArtService.WebApi.Models.CommentModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    public class CommentsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Создать новый комментарий к параграфу.
        /// </summary>
        /// <param name="createDto">Данные комментария</param>
        /// <returns>ID созданного комментария</returns>
        /// <response code="200">Комментарий успешно создан</response>
        /// <response code="400">Ошибка валидации</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCommentDto createDto)
        {
            var createCommand = _mapper.Map<CreateCommentCommand>(createDto);
            createCommand.UserId = UserId;
            var commentId = await Mediator.Send(createCommand);
            return Ok(commentId);
        }

        /// <summary>
        /// Обновить существующий комментарий.
        /// </summary>
        /// <param name="updateDto">Обновлённые данные комментария</param>
        /// <response code="204">Успешно обновлено</response>
        /// <response code="400">Неверные данные</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateCommentDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateCommentCommand>(updateDto);
            updateCommand.UserId = UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        /// <summary>
        /// Удалить комментарий по ID.
        /// </summary>
        /// <param name="commentId">ID комментария</param>
        /// <response code="204">Комментарий удалён</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpDelete("{commentId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid commentId)
        {
            var deleteCommand = new DeleteCommentCommand
            {
                UserId = UserId,
                CommentId = commentId
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        /// <summary>
        /// Получить комментарий по ID.
        /// </summary>
        /// <param name="commentId">ID комментария</param>
        /// <returns>Комментарий</returns>
        /// <response code="200">Комментарий найден</response>
        /// <response code="404">Комментарий не найден</response>
        [HttpGet("{commentId}")]
        [ProducesResponseType(typeof(CommentVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentVm>> Get(Guid commentId)
        {
            var query = new GetCommentQuery
            {
                CommentId = commentId
            };
            var commentVm = await Mediator.Send(query);
            return Ok(commentVm);
        }
    }
}
