using ArtService.Application.Reactions.Commands.SwitchReaction;
using ArtService.WebApi.Models.ReactionModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    public class ReactionController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Установить или отменить реакцию пользователя на параграф.
        /// </summary>
        /// <param name="switchDto">Данные о реакции</param>
        /// <response code="204">Реакция успешно установлена или удалена</response>
        /// <response code="400">Некорректный запрос</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Switch([FromBody] SwitchReactionDto switchDto)
        {
            var switchCommand = _mapper.Map<SwitchReactionCommand>(switchDto);
            switchCommand.UserId = UserId;
            await Mediator.Send(switchCommand);
            return NoContent();
        }
    }
}
