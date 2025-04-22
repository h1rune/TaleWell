using ArtService.Application.Volumes.Commands.CreateVolume;
using ArtService.Application.Volumes.Commands.DeleteVolume;
using ArtService.Application.Volumes.Commands.UpdateVolume;
using ArtService.Application.Volumes.Queries.GetVolume;
using ArtService.WebApi.Models.VolumeModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    [Route("[controller]")]
    public class VolumeController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Создание нового тома для произведения.
        /// </summary>
        /// <param name="createDto">Данные тома</param>
        /// <returns>ID созданного тома</returns>
        /// <response code="200">Успешное создание</response>
        /// <response code="400">Неверные данные</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateVolumeDto createDto)
        {
            var createCommand = _mapper.Map<CreateVolumeCommand>(createDto);
            createCommand.UserId = UserId;
            var reviewId = await Mediator.Send(createCommand);
            return Ok(reviewId);
        }

        /// <summary>
        /// Обновление информации о томе.
        /// </summary>
        /// <param name="updateDto">Обновленные данные</param>
        /// <returns>Результат выполнения</returns>
        /// <response code="204">Обновление прошло успешно</response>
        /// <response code="400">Неверные данные</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromForm] UpdateVolumeDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateVolumeCommand>(updateDto);
            updateCommand.UserId = UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        /// <summary>
        /// Удаление тома по идентификатору.
        /// </summary>
        /// <param name="volumeId">ID тома</param>
        /// <response code="204">Удаление успешно</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpDelete("{volumeId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid volumeId)
        {
            var deleteCommand = new DeleteVolumeCommand
            {
                VolumeId = volumeId,
                UserId = UserId
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        /// <summary>
        /// Получение тома по идентификатору.
        /// </summary>
        /// <param name="volumeId">ID тома</param>
        /// <returns>Информация о томе</returns>
        /// <response code="200">Успешное получение</response>
        /// <response code="404">Том не найден</response>
        [HttpGet("{volumeId}")]
        [ProducesResponseType(typeof(VolumeVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VolumeVm>> Get(Guid volumeId)
        {
            var query = new GetVolumeQuery
            {
                VolumeId = volumeId
            };
            var volumeVm = await Mediator.Send(query);
            return Ok(volumeVm);
        }
    }
}
