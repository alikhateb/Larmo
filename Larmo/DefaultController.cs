using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DefaultController : ControllerBase
{
    private IHttpContextAccessor _contextAccessor;
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected IHttpContextAccessor HttpContextAccessor =>
        _contextAccessor ??= HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();
}