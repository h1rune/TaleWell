using ArtService.Application.Chapters.Queries.GetVolumeChapters;
using ArtService.Application.Volumes.Commands.CreateVolume;
using ArtService.Application.Volumes.Commands.DeleteVolume;
using ArtService.Application.Volumes.Commands.UpdateVolume;
using ArtService.Application.Volumes.Queries.GetVolume;
using ArtService.WebApi.Models.VolumeModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Controllers
{
    public class VolumesController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Volume was successfully added to database.", typeof(Guid))]
        [EndpointDescription("This operation writes to database information about new volume of literary work and return the ID.")]
        public async Task<ActionResult<Guid>> Create(
            [FromForm, SwaggerParameter("Information about new volume")] 
            CreateVolumeDto createDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateVolumeCommand>(createDto);
            command.UserId = UserId;
            var volumeId = await Mediator.Send(command, cancellationToken);
            var location = Url.Action(nameof(Get), "Volumes", new {volumeId});
            return Created(location, volumeId);
        }

        [HttpPut("{volumeId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Volume was successfully updated.")]
        [EndpointDescription("This operation updates information about volume of literary work by ID.")]
        public async Task<IActionResult> Update(
            [SwaggerParameter("ID of updating volume")]
            Guid volumeId,
            [FromForm, SwaggerParameter("Information about volume")] 
            UpdateVolumeDto updateDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateVolumeCommand>(updateDto);
            command.UserId = UserId;
            command.VolumeId = volumeId;
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{volumeId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Volume was successfully deleted.")]
        [EndpointDescription("This operation deletes information about volume of literary work by ID.")]
        public async Task<IActionResult> Delete(
            [SwaggerParameter("ID of deleting volume")]
            Guid volumeId,
            CancellationToken cancellationToken)
        {
            var command = new DeleteVolumeCommand
            {
                VolumeId = volumeId,
                UserId = UserId
            };
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{volumeId:guid}")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Volume was successfully received.", typeof(VolumeVm))]
        [EndpointDescription("This operation receives information about volume of literary work by ID.")]
        public async Task<ActionResult<VolumeVm>> Get(
            [SwaggerParameter("ID of receiving volume")]
            Guid volumeId,
            CancellationToken cancellationToken)
        {
            var query = new GetVolumeQuery { VolumeId = volumeId };
            var volumeVm = await Mediator.Send(query, cancellationToken);
            return Ok(volumeVm);
        }

        [HttpGet("{volumeId:guid}/chapters")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Volume'chapters were successfully received.", typeof(VolumeChaptersVm))]
        [EndpointDescription("This operation receives information about chapters of volume by ID.")]
        public async Task<ActionResult<VolumeChaptersVm>> GetChapters(
            [SwaggerParameter("ID of volume for chapters")]
            Guid volumeId,
            CancellationToken cancellationToken)
        {
            var query = new GetVolumeChaptersQuery { VolumeId = volumeId };
            var chaptersVm = await Mediator.Send(query, cancellationToken);
            return Ok(chaptersVm);
        }
    }
}
