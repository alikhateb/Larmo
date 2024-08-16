using Larmo.Core.Application.Users.Create;
using Larmo.Core.Application.Users.logIn;
using Larmo.Core.Services;
using Larmo.Shared.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class UsersController : DefaultController
{
    [HttpPost("create")]
    public async Task<ActionResult<AccessTokenResult>> Create([FromBody] CreateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AccessTokenResult>> LogIn([FromBody] LogInCommand command,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}