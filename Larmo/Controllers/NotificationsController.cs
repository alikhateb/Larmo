using Larmo.Core.Application.Notifications;
using Larmo.Core.Application.Notifications.Add;
using Larmo.Core.Application.Notifications.GenderLookup;
using Larmo.Core.Application.Notifications.GetViewCollection;
using Larmo.Core.Application.Notifications.MakeAsRead;
using Larmo.Core.Application.Notifications.MaritalStatusLookup;
using Larmo.Shared.Application.Paging;
using Larmo.Shared.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers;

[Authorize]
[Route("api/[controller]")]
public class NotificationsController : DefaultController
{
    [HttpGet]
    public async Task<ActionResult<PageResponse<NotificationResult>>> GetAll([FromQuery] GetNotificationCollectionQuery query,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddNotificationCommand command, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPut("{notificationId:int}/checked")]
    public async Task<ActionResult> Checked([FromRoute] int notificationId, CancellationToken cancellationToken = default)
    {
        var command = new MakeAsReadCommand();
        command.SetId(notificationId);
        await Mediator.Send(command, cancellationToken);
        return Ok();
    }

    [AllowAnonymous]
    [HttpGet("gender-lookup")]
    public async Task<ActionResult<GenderLookupQuery[]>> GenderLookup(CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(new GenderLookupQuery(), cancellationToken));
    }

    [AllowAnonymous]
    [HttpGet("marital-status-lookup")]
    public async Task<ActionResult<MaritalStatusLookupQuery[]>> MaritalStatusLookup(CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(new MaritalStatusLookupQuery(), cancellationToken));
    }
}