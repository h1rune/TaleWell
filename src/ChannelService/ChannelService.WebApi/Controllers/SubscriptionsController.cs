using AutoMapper;
using ChannelService.Application.Subscriptions.Commands.CreateSubscription;
using ChannelService.Application.Subscriptions.Commands.DeleteSubscription;
using ChannelService.Application.Subscriptions.Queries.GetSubscriptions;
using ChannelService.WebApi.Models.SubscriptionModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChannelService.WebApi.Controllers
{
    public class SubscriptionsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateSubscriptionDto createDto, CancellationToken cancellationToken)
        {
            var createCommand = _mapper.Map<CreateSubscriptionCommand>(createDto);
            createCommand.FollowerId = AccountId;
            await Mediator.Send(createCommand, cancellationToken);
            return Created();
        }

        [HttpDelete("{followedId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid followedId, CancellationToken cancellationToken)
        {
            var deleteCommand = new DeleteSubscriptionCommand
            {
                FollowerId = AccountId,
                FollowedId = followedId
            };
            await Mediator.Send(deleteCommand, cancellationToken);
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<SubscriptionsVm>> Get(CancellationToken cancellationToken)
        {
            var query = new GetSubscriptionsQuery { ActorId = AccountId };
            var subscriptionsVm = await Mediator.Send(query, cancellationToken);
            return Ok(subscriptionsVm);
        }
    }
}
