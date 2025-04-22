using ArtService.Application.Works.Commands.CreateWork;
using ArtService.Application.Works.Commands.DeleteWork;
using ArtService.Application.Works.Commands.UpdateWork;
using ArtService.Application.Works.Queries.GetFanfics;
using ArtService.Application.Works.Queries.GetWork;
using ArtService.Application.Works.Queries.GetWorks;
using ArtService.WebApi.Models.WorkModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    [Route("[controller]")]
    public class WorkController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Создает новое литературное произведение.
        /// </summary>
        /// <param name="createDto">Данные для создания произведения.</param>
        /// <returns>Возвращает идентификатор созданного произведения.</returns>
        /// <response code="200">Возвращает идентификатор произведения, если создание прошло успешно.</response>
        /// <response code="400">Неверный запрос. Возможно, не все обязательные поля были указаны.</response>
        /// <response code="401">Неавторизованный доступ.</response>
        /// <response code="500">Внутренняя ошибка сервера.</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Guid), 200)]  // Успешный ответ с идентификатором произведения
        [ProducesResponseType(400)]  // Неверный запрос
        [ProducesResponseType(401)]  // Неавторизованный доступ
        [ProducesResponseType(500)]  // Внутренняя ошибка сервера
        public async Task<ActionResult<Guid>> Create([FromBody] CreateWorkDto createDto)
        {
            var createCommand = _mapper.Map<CreateWorkCommand>(createDto);
            createCommand.UserId = UserId;
            Guid channelId = await Mediator.Send(createCommand);
            return Ok(channelId);
        }

        /// <summary>
        /// Обновляет литературное произведение по указанному идентификатору.
        /// </summary>
        /// <param name="updateDto">Данные для обновления произведения.</param>
        /// <returns>Статус выполнения операции (204 No Content).</returns>
        /// <response code="204">Произведение успешно обновлено.</response>
        /// <response code="400">Неверный запрос. Возможно, не все обязательные поля были указаны.</response>
        /// <response code="401">Неавторизованный доступ.</response>
        /// <response code="404">Произведение с указанным идентификатором не найдено.</response>
        /// <response code="500">Внутренняя ошибка сервера.</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(204)]  // Успешный ответ без контента
        [ProducesResponseType(400)]  // Неверный запрос
        [ProducesResponseType(401)]  // Неавторизованный доступ
        [ProducesResponseType(404)]  // Произведение не найдено
        [ProducesResponseType(500)]  // Внутренняя ошибка сервера
        public async Task<IActionResult> Update([FromBody] UpdateWorkDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateWorkCommand>(updateDto);
            updateCommand.UserId = UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        /// <summary>
        /// Удаляет литературное произведение по указанному идентификатору.
        /// </summary>
        /// <param name="workId">Идентификатор произведения, которое нужно удалить.</param>
        /// <returns>Статус выполнения операции (204 No Content).</returns>
        /// <response code="204">Произведение успешно удалено.</response>
        /// <response code="400">Неверный запрос. Возможно, не все обязательные поля были указаны.</response>
        /// <response code="401">Неавторизованный доступ.</response>
        /// <response code="404">Произведение с указанным идентификатором не найдено.</response>
        /// <response code="500">Внутренняя ошибка сервера.</response>
        [HttpDelete("{workId}")]
        [Authorize]
        [ProducesResponseType(204)]  // Успешный ответ без контента
        [ProducesResponseType(400)]  // Неверный запрос
        [ProducesResponseType(401)]  // Неавторизованный доступ
        [ProducesResponseType(404)]  // Произведение не найдено
        [ProducesResponseType(500)]  // Внутренняя ошибка сервера
        public async Task<IActionResult> Delete(Guid workId)
        {
            var deleteCommand = new DeleteWorkCommand
            {
                UserId = UserId,
                WorkId = workId
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        /// <summary>
        /// Получает литературное произведение по его идентификатору.
        /// </summary>
        /// <param name="workId">Идентификатор произведения.</param>
        /// <returns>Возвращает информацию о произведении.</returns>
        /// <response code="200">Возвращает произведение с указанным идентификатором.</response>
        /// <response code="400">Неверный запрос.</response>
        /// <response code="401">Неавторизованный доступ.</response>
        /// <response code="404">Произведение с указанным идентификатором не найдено.</response>
        /// <response code="500">Внутренняя ошибка сервера.</response>
        [HttpGet("{workId}")]
        [ProducesResponseType(typeof(WorkVm), 200)]  // Успешный ответ с произведением
        [ProducesResponseType(400)]  // Неверный запрос
        [ProducesResponseType(401)]  // Неавторизованный доступ
        [ProducesResponseType(404)]  // Произведение не найдено
        [ProducesResponseType(500)]  // Внутренняя ошибка сервера
        public async Task<ActionResult<WorkVm>> Get(Guid workId)
        {
            var query = new GetWorkQuery
            {
                WorkId = workId
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        /// <summary>
        /// Получает список литературных произведений по заданным фильтрам.
        /// </summary>
        /// <param name="getDto">Фильтры для получения списка произведений.</param>
        /// <returns>Возвращает список произведений.</returns>
        /// <response code="200">Возвращает список произведений, если запрос успешен.</response>
        /// <response code="400">Неверный запрос. Возможно, не все обязательные параметры были указаны.</response>
        /// <response code="401">Неавторизованный доступ.</response>
        /// <response code="500">Внутренняя ошибка сервера.</response>
        [HttpGet("list")]
        [ProducesResponseType(typeof(WorksVm), 200)]  // Успешный ответ с объектом списка произведений
        [ProducesResponseType(400)]  // Неверный запрос
        [ProducesResponseType(401)]  // Неавторизованный доступ
        [ProducesResponseType(500)]  // Внутренняя ошибка сервера
        public async Task<ActionResult<WorksVm>> GetWorks([FromBody] GetWorksDto getDto)
        {
            var getQuery = _mapper.Map<GetWorksQuery>(getDto);
            WorksVm worksVm = await Mediator.Send(getQuery);
            return Ok(worksVm);
        }

        /// <summary>
        /// Получает список фанфиков произведения.
        /// </summary>
        /// <param name="getDto">Фильтры для получения списка фанфиков.</param>
        /// <returns>Возвращает список фанфиков.</returns>
        /// <response code="200">Возвращает список фанфиков, если запрос успешен.</response>
        /// <response code="400">Неверный запрос. Возможно, не все обязательные параметры были указаны.</response>
        /// <response code="401">Неавторизованный доступ.</response>
        /// <response code="500">Внутренняя ошибка сервера.</response>
        [HttpGet("fanfics")]
        [ProducesResponseType(typeof(FanficsVm), 200)]  // Успешный ответ с объектом списка фанфиков
        [ProducesResponseType(400)]  // Неверный запрос
        [ProducesResponseType(401)]  // Неавторизованный доступ
        [ProducesResponseType(500)]  // Внутренняя ошибка сервера
        public async Task<ActionResult<FanficsVm>> GetFanfics([FromBody] GetFanficsDto getDto)
        {
            var getQuery = _mapper.Map<GetFanficsQuery>(getDto);
            FanficsVm worksVm = await Mediator.Send(getQuery);
            return Ok(worksVm);
        }
    }
}
