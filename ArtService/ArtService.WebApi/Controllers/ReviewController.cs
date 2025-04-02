using ArtService.Application.Reviews.Commands.CreateReview;
using ArtService.Application.Reviews.Commands.DeleteReview;
using ArtService.Application.Reviews.Commands.UpdateReview;
using ArtService.Application.Reviews.Queries.GetReview;
using ArtService.Application.Reviews.Queries.GetWorkReviews;
using ArtService.WebApi.Models.ReviewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ReviewController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReviewDto createDto)
        {
            var createCommand = _mapper.Map<CreateReviewCommand>(createDto);
            createCommand.UserId = UserId;
            var reviewId = await Mediator.Send(createCommand);
            return Ok(reviewId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReviewDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateReviewCommand>(updateDto);
            updateCommand.UserId = UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> Delete(Guid reviewId)
        {
            var deleteCommand = new DeleteReviewCommand
            {
                UserId = UserId,
                ReviewId = reviewId
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpGet("{reviewId}")]
        public async Task<ActionResult<ReviewVm>> Get(Guid reviewId)
        {
            var query = new GetReviewQuery { ReviewId = reviewId };
            var reviewVm = await Mediator.Send(query);
            return Ok(reviewVm);
        }

        [HttpGet("list")]
        public async Task<ActionResult<WorkReviewsVm>> GetWorkReviews([FromBody] GetWorkReviewsDto workReviewsDto)
        {
            var query = _mapper.Map<GetWorkReviewsQuery>(workReviewsDto);
            var workReviewsVm = await Mediator.Send(query);
            return Ok(workReviewsVm);
        }
    }
}
