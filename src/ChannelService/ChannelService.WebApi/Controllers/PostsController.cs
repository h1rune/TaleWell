using AutoMapper;
using ChannelService.Application.Posts.Commands.CreatePost;
using ChannelService.Application.Posts.Commands.DeletePost;
using ChannelService.Application.Posts.Commands.UpdatePost;
using ChannelService.Application.Posts.Queries.GetChannelPosts;
using ChannelService.WebApi.Models.PostModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChannelService.WebApi.Controllers
{
    public class PostsController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostDto createDto)
        {
            var createCommand = _mapper.Map<CreatePostCommand>(createDto);
            createCommand.ChannelId = AccountId;
            var postId = await Mediator.Send(createCommand);
            return Ok(postId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdatePostDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdatePostCommand>(updateDto);
            updateCommand.ChannelId = AccountId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpDelete("{postId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid postId)
        {
            var deleteCommand = new DeletePostCommand
            {
                ChannelId = AccountId,
                PostId = postId
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ChannelPostsVm>> GetChannelPosts([FromQuery] GetChannelPostsDto getDto)
        {
            var query = _mapper.Map<GetChannelPostsQuery>(getDto);
            query.ActorId = AccountId;
            var postsVm = await Mediator.Send(query);
            return Ok(postsVm);
        }
    }
}
