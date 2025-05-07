using ArtService.Application.Reviews.Commands.CreateReview;
using ArtService.Application.Reviews.Commands.DeleteReview;
using ArtService.Application.Reviews.Commands.UpdateReview;
using ArtService.Application.Reviews.Queries.GetReview;
using ArtService.WebApi.Models.ReviewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Controllers
{
    public class ReviewsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Review was successfully added to database.", typeof(Guid))]
        [EndpointDescription("This operation writes to database information about new review for literary work and return the ID.")]
        public async Task<ActionResult<Guid>> Create(
            [FromBody, SwaggerRequestBody("Information about review.")] 
            CreateReviewDto createDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateReviewCommand>(createDto);
            command.UserId = UserId;
            var reviewId = await Mediator.Send(command, cancellationToken);
            var location = Url.Action(nameof(Get), "Reviews", new { reviewId });
            return Created(location, reviewId);
        }

        [HttpPut("{reviewId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Review was successfully updated.")]
        [SwaggerOperation("This operation updates information about literary work review.")]
        public async Task<IActionResult> Update(
            [SwaggerParameter("Updating review's ID.")] 
            Guid reviewId, 
            [FromBody, SwaggerRequestBody("Information about review.")] 
            UpdateReviewDto updateDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateReviewCommand>(updateDto);
            command.ReviewId = reviewId;
            command.UserId = UserId;
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{reviewId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Review was successfully deleted.")]
        [EndpointDescription("This operation deletes information about literary work review.")]
        public async Task<IActionResult> Delete(
            [SwaggerParameter("Deleting review's ID.")] 
            Guid reviewId,
            CancellationToken cancellationToken)
        {
            var command = new DeleteReviewCommand
            {
                UserId = UserId,
                ReviewId = reviewId
            };
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{reviewId:guid}")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Review was received.", typeof(ReviewVm))]
        [EndpointDescription("This operation returns information about review by ID.")]
        public async Task<ActionResult<ReviewVm>> Get(
            [SwaggerParameter("Receiving review's ID.")] 
            Guid reviewId,
            CancellationToken cancellationToken)
        {
            var query = new GetReviewQuery { ReviewId = reviewId };
            var reviewVm = await Mediator.Send(query, cancellationToken);
            return Ok(reviewVm);
        }
    }
}
