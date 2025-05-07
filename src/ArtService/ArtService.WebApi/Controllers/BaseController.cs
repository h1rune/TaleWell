using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace ArtService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Resource not found.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Not valid parameter.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server is not responding.")]
    public abstract class BaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        protected IMediator Mediator => _mediator;

        protected Guid UserId
        {
            get
            {
                if (User.Identity?.IsAuthenticated == false)
                {
                    throw new UnauthorizedAccessException();
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (Guid.TryParse(userIdClaim, out var userId))
                {
                    return userId;
                }

                throw new UnauthorizedAccessException();
            }
        }
    }
}
