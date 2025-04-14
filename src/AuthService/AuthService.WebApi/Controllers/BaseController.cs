using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public abstract class BaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        protected IMediator Mediator => _mediator;
    }
}
