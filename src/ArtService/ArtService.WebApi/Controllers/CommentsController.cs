using ArtService.Application.Comments.Commands.CreateComment;
using ArtService.Application.Comments.Commands.DeleteComment;
using ArtService.Application.Comments.Commands.UpdateComment;
using ArtService.Application.Comments.Queries.GetComment;
using ArtService.Application.Comments.Queries.GetParagraph;
using ArtService.WebApi.Models.CommentModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Controllers
{
    public class CommentsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Comment was successfully added to database.", typeof(Guid))]
        [EndpointDescription("This operation writes to database information about new comment for paragraph and return the ID.")]
        public async Task<ActionResult<Guid>> Create(
            [FromBody, SwaggerRequestBody("Information about new comment")] 
            CreateCommentDto createDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateCommentCommand>(createDto);
            command.UserId = UserId;
            var commentId = await Mediator.Send(command, cancellationToken);
            var location = Url.Action(nameof(Get), "Comments", commentId);
            return Created(location, commentId);
        }

        [HttpPut("{commentId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Comment was successfully updated.")]
        [EndpointDescription("This operation updates information about comment by ID.")]
        public async Task<IActionResult> Update(
            [SwaggerParameter("ID of updating comment")]
            Guid commentId,
            [FromBody, SwaggerRequestBody("Information about comment")] 
            UpdateCommentDto updateDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateCommentCommand>(updateDto);
            command.UserId = UserId;
            command.CommentId = commentId;
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{commentId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Comment was successfully deleted.")]
        [EndpointDescription("This operation deletes information about comment by ID.")]
        public async Task<IActionResult> Delete(
            [SwaggerParameter("ID of comment to delete")]
            Guid commentId,
            CancellationToken cancellationToken)
        {
            var command = new DeleteCommentCommand
            {
                UserId = UserId,
                CommentId = commentId
            };
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{commentId:guid}")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Comment was successfully received.", typeof(CommentVm))]
        [EndpointDescription("This operation receives information about comment by ID.")]
        public async Task<ActionResult<CommentVm>> Get(
            [SwaggerParameter("ID of comment to receive")]
            Guid commentId,
            CancellationToken cancellationToken)
        {
            var query = new GetCommentQuery { CommentId = commentId };
            var commentVm = await Mediator.Send(query, cancellationToken);
            return Ok(commentVm);
        }
    }
}
