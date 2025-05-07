using ArtService.Application.Reviews.Queries.GetWorkReviews;
using ArtService.Application.Volumes.Queries.GetWorkVolumes;
using ArtService.Application.Works.Commands.CreateWork;
using ArtService.Application.Works.Commands.DeleteWork;
using ArtService.Application.Works.Commands.UpdateWork;
using ArtService.Application.Works.Queries.GetFanfics;
using ArtService.Application.Works.Queries.GetWork;
using ArtService.Application.Works.Queries.GetWorks;
using ArtService.WebApi.Models.Common;
using ArtService.WebApi.Models.WorkModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Controllers
{
    public class WorksController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Literary work was successfully added to database.", typeof(Guid))]
        [EndpointDescription("This operation writes to database information about new literary work and return the ID.")]
        public async Task<ActionResult<Guid>> Create(
            [FromBody, SwaggerRequestBody("Information about literary work.")] 
            CreateWorkDto createDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateWorkCommand>(createDto);
            command.UserId = UserId;
            var workId = await Mediator.Send(command, cancellationToken);
            var location = Url.Action(nameof(Get), "Works", new { workId });
            return Created(location, workId);
        }

        [HttpPut("{workId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Literary work was successfully updated.")]
        [EndpointDescription("This operation updates information about literary work.")]
        public async Task<IActionResult> Update(
            [SwaggerParameter("Literary work's ID.")] 
            Guid workId, 
            [FromBody, SwaggerRequestBody("Information about literary work.")] 
            UpdateWorkDto updateDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateWorkCommand>(updateDto);
            command.WorkId = workId;
            command.UserId = UserId;
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{workId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Literary work was successfully deleted.")]
        [EndpointDescription("This operation deletes record about literary work from database by ID.")]
        public async Task<IActionResult> Delete(
            [SwaggerParameter("ID of literary work.")] 
            Guid workId, 
            CancellationToken cancellationToken)
        {
            var command = new DeleteWorkCommand
            {
                UserId = UserId,
                WorkId = workId
            };
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{workId:guid}")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Literary work was received.", typeof(WorkVm))]
        [EndpointDescription("This operation returns information about literary work by ID.")]
        public async Task<ActionResult<WorkVm>> Get(
            [SwaggerParameter("ID of literary work.")] 
            Guid workId, 
            CancellationToken cancellationToken)
        {
            var query = new GetWorkQuery { WorkId = workId };
            var viewModel = await Mediator.Send(query, cancellationToken);
            return Ok(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Literary works were received.", typeof(WorksVm))]
        [EndpointDescription("This operation returns list with information about literary works.")]
        public async Task<ActionResult<WorksVm>> GetWorks(
            [FromQuery, SwaggerParameter("Offset and limit for received list.")] 
            ListSettingsDto getDto, 
            CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetWorksQuery>(getDto);
            var worksVm = await Mediator.Send(query, cancellationToken);
            return Ok(worksVm);
        }

        [HttpGet("{originalId:guid}/fanfics")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Fanfics were received.", typeof(FanficsVm))]
        [EndpointDescription("This operation returns list with information about fanfics for literary work.")]
        public async Task<ActionResult<FanficsVm>> GetFanfics(
            [SwaggerParameter("ID of original literary work.")] 
            Guid originalId, 
            [FromQuery, SwaggerParameter("Offset and limit for received list.")] 
            ListSettingsDto getDto,
            CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetFanficsQuery>(getDto);
            query.OriginalId = originalId;
            var fanficsVm = await Mediator.Send(query, cancellationToken);
            return Ok(fanficsVm);
        }

        [HttpGet("{workId:guid}/reviews")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Reviews were received.", typeof(WorkReviewsVm))]
        [EndpointDescription("This operation returns list with information about reviews for literary work.")]
        public async Task<ActionResult<WorkReviewsVm>> GetWorkReviews(
            [SwaggerParameter("Literary work's ID.")] 
            Guid workId, 
            [FromQuery, SwaggerParameter("Offset and limit for received list.")] 
            ListSettingsDto getDto,
            CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetWorkReviewsQuery>(getDto);
            query.WorkId = workId;
            var workReviewsVm = await Mediator.Send(query, cancellationToken);
            return Ok(workReviewsVm);
        }

        [HttpGet("{workId:guid}/volumes")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Volumes were received.", typeof(WorkVolumesVm))]
        [EndpointDescription("This operation returns list with information about volumes of literary work.")]
        public async Task<ActionResult<WorkVolumesVm>> GetWorkVolumes(
            [SwaggerParameter("Literary work's ID.")]
            Guid workId,
            CancellationToken cancellationToken)
        {
            var query = new GetWorkVolumesQuery { WorkId = workId };
            var volumesVm = await Mediator.Send(query, cancellationToken);
            return Ok(volumesVm);
        }
    }
}
