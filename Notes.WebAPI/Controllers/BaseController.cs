using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notes.WebAPI.Controllers
{
    /// <summary>
    /// provides some shared mwthods for all controls.
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        /// <summary>
        /// Gets Mediator for CQRS.
        /// </summary>
        protected IMediator Mediator =>
            _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        //TODO: Remove? I don't have a front here.
        /// <summary>
        /// Grts Current User Id.
        /// </summary>
        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
