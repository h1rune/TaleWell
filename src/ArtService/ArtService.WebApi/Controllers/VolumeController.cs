using ArtService.Application.Volumes.Commands.CreateVolume;
using ArtService.WebApi.Models.VolumeModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    [Route("[controller]")]
    public class VolumeController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateVolumeDto createDto)
        {
            var createCommand = _mapper.Map<CreateVolumeCommand>(createDto);
            createCommand.UserId = UserId;
            var reviewId = await Mediator.Send(createCommand);
            return Ok(reviewId);
        }
    }
}
