using ArtService.Application.Works.Commands.CreateWork;
using ArtService.Application.Works.Commands.DeleteWork;
using ArtService.Application.Works.Commands.UpdateWork;
using ArtService.Application.Works.Queries.GetFanfics;
using ArtService.Application.Works.Queries.GetWork;
using ArtService.Application.Works.Queries.GetWorks;
using ArtService.WebApi.Models.WorkModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class WorkController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateWorkDto createDto)
        {
            var createCommand = _mapper.Map<CreateWorkCommand>(createDto);
            createCommand.UserId = UserId;
            Guid channelId = await Mediator.Send(createCommand);
            return Ok(channelId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWorkDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateWorkCommand>(updateDto);
            updateCommand.UserId = UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteCommand = new DeleteWorkCommand
            {
                UserId = UserId,
                WorkId = id
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkVm>> Get(Guid id)
        {
            var query = new GetWorkQuery
            {
                WorkId = id
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpGet("list")]
        public async Task<ActionResult<WorksVm>> GetWorks([FromBody] GetWorksDto getDto)
        {
            var getQuery = _mapper.Map<GetWorksQuery>(getDto);
            WorksVm worksVm = await Mediator.Send(getQuery);
            return Ok(worksVm);
        }

        [HttpGet("fanfics")]
        public async Task<ActionResult<FanficsVm>> GetFanfics([FromBody] GetFanficsDto getDto)
        {
            var getQuery = _mapper.Map<GetFanficsQuery>(getDto);
            FanficsVm worksVm = await Mediator.Send(getQuery);
            return Ok(worksVm);
        }
    }
}
