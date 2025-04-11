using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArtService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        protected IMediator Mediator => _mediator;

        internal Guid UserId
        {
            get
            {
                if (User.Identity?.IsAuthenticated == false)
                {
                    return Guid.Empty;
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Guid.TryParse(userIdClaim, out var userId) ? userId : Guid.Empty;
            }
        }
    }
}
