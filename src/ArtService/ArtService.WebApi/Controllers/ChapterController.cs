using ArtService.Application.Chapters.Commands.CreateChapter;
using ArtService.Application.Chapters.Commands.DeleteChapter;
using ArtService.Application.Chapters.Commands.UpdateChapter;
using ArtService.Application.Chapters.Queries.GetChapter;
using ArtService.WebApi.Models.ChapterModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    public class ChapterController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Создать новую главу.
        /// </summary>
        /// <param name="createDto">Данные для создания главы</param>
        /// <returns>ID созданной главы</returns>
        /// <response code="200">Глава успешно создана</response>
        /// <response code="400">Неверные данные</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateChapterDto createDto)
        {
            var createCommand = _mapper.Map<CreateChapterCommand>(createDto);
            createCommand.UserId = UserId;
            var chapterId = await Mediator.Send(createCommand);
            return Ok(chapterId);
        }

        /// <summary>
        /// Обновить главу.
        /// </summary>
        /// <param name="updateDto">Обновленные данные главы</param>
        /// <response code="204">Глава успешно обновлена</response>
        /// <response code="400">Неверные данные</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateChapterDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateChapterCommand>(updateDto);
            updateCommand.UserId = UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        /// <summary>
        /// Удалить главу по ID.
        /// </summary>
        /// <param name="chapterId">ID главы</param>
        /// <response code="204">Удаление прошло успешно</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpDelete("{chapterId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid chapterId)
        {
            var deleteCommand = new DeleteChapterCommand
            {
                UserId = UserId,
                ChapterId = chapterId
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        /// <summary>
        /// Получить главу по ID.
        /// </summary>
        /// <param name="chapterId">ID главы</param>
        /// <returns>Модель представления главы</returns>
        /// <response code="200">Успешно</response>
        /// <response code="404">Глава не найдена</response>
        [HttpGet("{chapterId}")]
        [ProducesResponseType(typeof(ChapterVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ChapterVm>> Get(Guid chapterId)
        {
            var query = new GetChapterQuery
            {
                ChapterId = chapterId
            };
            var chapterVm = await Mediator.Send(query); 
            return Ok(chapterVm);
        }
    }
}
