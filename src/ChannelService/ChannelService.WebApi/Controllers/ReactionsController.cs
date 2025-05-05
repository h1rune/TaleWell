using AutoMapper;
using ChannelService.Application.Reactions.Commands.CreateReaction;
using ChannelService.Application.Reactions.Commands.DeleteReaction;
using ChannelService.WebApi.Models.ReactionModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChannelService.WebApi.Controllers
{
    public class ReactionsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReactionDto createDto)
        {
            var createCommand = _mapper.Map<CreateReactionCommand>(createDto);
            createCommand.ActorId = AccountId;
            var reactionId = await Mediator.Send(createCommand);
            return Ok(reactionId);
        }

        [HttpDelete("{reactionId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid reactionId)
        {
            var deleteCommand = new DeleteReactionCommand
            {
                ReactionId = reactionId,
                ActorId = AccountId
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
