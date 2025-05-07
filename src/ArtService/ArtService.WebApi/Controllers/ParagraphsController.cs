using ArtService.Application.Comments.Queries.GetParagraphComments;
using ArtService.Application.Paragraphs.Commands.CreateParagraph;
using ArtService.Application.Paragraphs.Commands.DeleteParagraph;
using ArtService.Application.Paragraphs.Commands.UpdateParagraph;
using ArtService.Application.Paragraphs.Queries.GetParagraph;
using ArtService.Application.Reactions.Queries.GetParagraphReactions;
using ArtService.WebApi.Models.Common;
using ArtService.WebApi.Models.ParagraphModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Controllers
{
    public class ParagraphsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Paragraph was successfully added to database.", typeof(Guid))]
        [EndpointDescription("This operation writes to database information about new paragraph of chapter and return the ID.")]
        public async Task<ActionResult<Guid>> Create(
            [FromBody, SwaggerRequestBody("Information about new paragraph")] 
            CreateParagraphDto createDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateParagraphCommand>(createDto);
            command.UserId = UserId;
            var paragraphId = await Mediator.Send(command, cancellationToken);
            var location = Url.Action(nameof(Get), "Paragraphs", new { paragraphId });
            return Created(location, paragraphId);
        }

        [HttpPut("{paragraphId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Paragraph was successfully updated.")]
        [EndpointDescription("This operation updates information about paragraph by ID.")]
        public async Task<IActionResult> Update(
            [SwaggerParameter("ID of updating paragraph")]
            Guid paragraphId,
            [FromBody, SwaggerRequestBody("Information about paragraph")] 
            UpdateParagraphDto updateDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateParagraphCommand>(updateDto);
            command.UserId = UserId;
            command.ParagraphId = paragraphId;
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{paragraphId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Paragraph was successfully deleted.")]
        [EndpointDescription("This operation deletes information about parahraph by ID.")]
        public async Task<IActionResult> Delete(
            [SwaggerParameter("ID of paragraph to delete")]
            Guid paragraphId,
            CancellationToken cancellationToken)
        {
            var command = new DeleteParagraphCommand
            {
                ParagraphId = paragraphId,
                UserId = UserId 
            };
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{paragraphId:guid}")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Paragraph was successfully received.", typeof(ParagraphVm))]
        [EndpointDescription("This operation receives information about paragraph by ID.")]
        public async Task<ActionResult<ParagraphVm>> Get(
            [SwaggerParameter("ID of paragraph")]
            Guid paragraphId,
            CancellationToken cancellationToken)
        {
            var query = new GetParagraphQuery { ParagraphId = paragraphId };
            var paragraphVm = await Mediator.Send(query, cancellationToken);
            return Ok(paragraphVm);
        }

        [HttpGet("{paragraphId:guid}/comments")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Paragraph's comments were successfully received.", typeof(ParagraphCommentsVm))]
        [EndpointDescription("This operation receives information about paragraph's comments by ID.")]
        public async Task<ActionResult<ParagraphCommentsVm>> GetComments(
            [SwaggerParameter("ID of paragraph")]
            Guid paragraphId,
            ListSettingsDto settingsDto,
            CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetParagraphCommentsQuery>(settingsDto);
            query.ParagraphId = paragraphId;
            var commentsVm = await Mediator.Send(query, cancellationToken);
            return Ok(commentsVm);
        }

        [HttpGet("{paragraphId:guid}/reactions")]
        [SwaggerResponse(StatusCodes.Status200OK, "Paragraph's reactions were successfully received.", typeof(ParagraphReactionsVm))]
        [EndpointDescription("This operation receives information about paragraph's reactions by ID.")]
        public async Task<ActionResult<ParagraphReactionsVm>> GetReactions(
            [SwaggerParameter("ID of paragraph")]
            Guid paragraphId,
            CancellationToken cancellationToken)
        {
            var query = new GetParagraphReactionsQuery 
            { 
                ParagraphId = paragraphId,
                UserId = UserId,
            };
            var reactionsVm = await Mediator.Send(query, cancellationToken);
            return Ok(reactionsVm);
        }
    }
}
