using Larmo.Core.Application.Notifications;
using Larmo.Core.Application.Notifications.Add;
using Larmo.Core.Application.Notifications.GenderLookup;
using Larmo.Core.Application.Notifications.GetViewCollection;
using Larmo.Core.Application.Notifications.MakeAsRead;
using Larmo.Core.Application.Notifications.MaritalStatusLookup;
using Larmo.Core.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : DefaultController
    {
        [HttpGet]
        public async Task<ActionResult<PageResponse<NotificationResult>>> Add([FromQuery] GetNotificationCollectionQuery query,
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

        [HttpGet("gender-lookup")]
        public async Task<ActionResult<GenderLookupQuery[]>> GenderLookup(CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GenderLookupQuery(), cancellationToken));
        }

        [HttpGet("marital-status-lookup")]
        public async Task<ActionResult<MaritalStatusLookupQuery[]>> MaritalStatusLookup(CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new MaritalStatusLookupQuery(), cancellationToken));
        }

        [HttpPut("{notificationId:int}")]
        public async Task<ActionResult> MakeAs([FromRoute] int notificationId, CancellationToken cancellationToken = default)
        {
            var command = new MakeAsReadCommand();
            command.SetId(notificationId);
            await Mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
