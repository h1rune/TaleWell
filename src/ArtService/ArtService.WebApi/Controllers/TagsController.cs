using ArtService.Application.LiteraryTags.Queries.GetLiteraryTags;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Controllers
{
    public class TagsController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet()]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Tags were received.", typeof(LiteraryTagsVm))]
        [EndpointDescription("This operation returns information about tags.")]
        public async Task<ActionResult<LiteraryTagsVm>> Get(CancellationToken cancellationToken)
        {
            var query = new GetLiteraryTagsQuery();
            var tagsVm = await Mediator.Send(query, cancellationToken);
            return Ok(tagsVm);
        }

    }
}
