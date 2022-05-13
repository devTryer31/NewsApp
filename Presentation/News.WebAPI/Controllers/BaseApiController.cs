using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace News.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        private MediatR.IMediator _mediator;

        protected MediatR.IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<MediatR.IMediator>();

        internal Guid UserId =>
            !User.Identity.IsAuthenticated ?
            Guid.Empty :
            Guid.Parse(
                    HttpContext.RequestServices.GetService<UserManager<IdentityUser>>().GetUserId(User)
                );
    }
}
