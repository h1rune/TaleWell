using AutoMapper;
using ChannelService.Application.Channels.Commands.CreateChannel;
using ChannelService.Application.Channels.Commands.DeleteChannel;
using ChannelService.Application.Channels.Commands.UpdateChannel;
using ChannelService.Application.Channels.Queries.GetChannelByHandle;
using ChannelService.WebApi.Models.ChannelModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChannelService.WebApi.Controllers
{
    public class InfoController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateChannelDto createDto)
        {
            var createCommand = _mapper.Map<CreateChannelCommand>(createDto);
            createCommand.ChannelId = AccountId;
            await Mediator.Send(createCommand);
            return Created();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateChannelDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateChannelCommand>(updateDto);
            updateCommand.ChannelId = AccountId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            var deleteCommand = new DeleteChannelCommand { ChannelId = AccountId };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpGet("{channelHandle}")]
        [Authorize]
        public async Task<ActionResult<ChannelVm>> GetByHandle(string channelHandle)
        {
            var query = new GetChannelByHandleQuery 
            { 
                ChannelHandle = channelHandle,
                ActorId = AccountId
            };
            var channelVm = await Mediator.Send(query);
            return Ok(channelVm);
        }
    }
}
