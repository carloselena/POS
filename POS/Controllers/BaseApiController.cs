using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace POS.WebApi.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
