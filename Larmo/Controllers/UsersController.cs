using Larmo.Core.Application.Users.Create;
using Larmo.Core.Application.Users.CreateAdmin;
using Larmo.Core.Application.Users.logIn;
using Larmo.Core.Services;
using Larmo.Shared.Common;
using Larmo.Shared.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers;

[Authorize(Roles = RoleName.Admin)]
[Route("api/[controller]")]
public class UsersController : DefaultController
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost("admin")]
    public async Task<ActionResult> CreateAdmin(CancellationToken cancellationToken = default)
    {
        await Mediator.Send(new CreateAdminCommand(), cancellationToken);
        return Ok();
    }

    [HttpPost("create")]
    public async Task<ActionResult<AccessTokenResult>> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AccessTokenResult>> LogIn([FromBody] LogInCommand command, CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}