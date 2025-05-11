using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Resource not found.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Not valid parameter.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server is not responding.")]
    public abstract class BaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        protected IMediator Mediator => _mediator;
    }
}
