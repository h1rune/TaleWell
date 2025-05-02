using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChannelService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public abstract class BaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        protected IMediator Mediator => _mediator;

        internal Guid AccountId
        {
            get
            {
                if (User.Identity?.IsAuthenticated == false)
                {
                    return Guid.Empty;
                }

                var accountIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Guid.TryParse(accountIdClaim, out var accountId) ? accountId : Guid.Empty;
            }
        }
    }
}
