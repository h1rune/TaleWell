using ArtService.Application.Paragraphs.Commands.CreateParagraph;
using ArtService.Application.Paragraphs.Commands.DeleteParagraph;
using ArtService.Application.Paragraphs.Commands.UpdateParagraph;
using ArtService.Application.Paragraphs.Queries.GetParagraph;
using ArtService.WebApi.Models.ParagraphModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    public class ParagraphController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Создать новый параграф.
        /// </summary>
        /// <param name="createDto">Данные для создания параграфа</param>
        /// <returns>ID созданного параграфа</returns>
        /// <response code="200">Параграф успешно создан</response>
        /// <response code="400">Неверные входные данные</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateParagraphDto createDto)
        {
            var createCommand = _mapper.Map<CreateParagraphCommand>(createDto);
            createCommand.UserId = UserId;
            var paragraphId = await Mediator.Send(createCommand);
            return Ok(paragraphId);
        }

        /// <summary>
        /// Обновить существующий параграф.
        /// </summary>
        /// <param name="updateDto">Обновлённые данные</param>
        /// <response code="204">Успешно обновлено</response>
        /// <response code="400">Неверные данные</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateParagraphDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateParagraphCommand>(updateDto);
            updateCommand.UserId = UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        /// <summary>
        /// Удалить параграф по идентификатору.
        /// </summary>
        /// <param name="paragraphId">ID параграфа</param>
        /// <response code="204">Удаление успешно</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpDelete("{paragraphId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid paragraphId)
        {
            var deleteCommand = new DeleteParagraphCommand
            {
                ParagraphId = paragraphId,
                UserId = UserId 
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        /// <summary>
        /// Получить параграф по ID.
        /// </summary>
        /// <param name="paragraphId">ID параграфа</param>
        /// <returns>Модель представления параграфа</returns>
        /// <response code="200">Параграф найден</response>
        /// <response code="404">Параграф не найден</response>
        [HttpGet("{paragraphId}")]
        [ProducesResponseType(typeof(ParagraphVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ParagraphVm>> Get(Guid paragraphId)
        {
            var query = new GetParagraphQuery
            {
                ParagraphId = paragraphId
            };
            var paragraphVm = await Mediator.Send(query);
            return Ok(paragraphVm);
        }
    }
}
