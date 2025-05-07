using ArtService.Application.Reactions.Commands.SwitchReaction;
using ArtService.WebApi.Models.ReactionModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Controllers
{
    public class ReactionsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Reaction was successfully switched.")]
        [EndpointDescription("This operation switches reaction for paragraph.")]
        public async Task<IActionResult> Switch(
            [FromBody, SwaggerRequestBody("Information for switching reaction")] 
            SwitchReactionDto switchDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<SwitchReactionCommand>(switchDto);
            command.UserId = UserId;
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
