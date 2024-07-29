using Larmo.Core.Application.Add;
using Larmo.Core.Application.Update;
using Larmo.Core.Application.ViewCollection;
using Larmo.Core.Application.ViewDetails;
using Larmo.Core.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Larmo.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class OperationsController : DefaultController
    {
        [HttpGet]
        public async Task<ActionResult<PageResponse<OperationResult>>> GetAll([FromQuery] GetOperationCollectionQuery query,
            CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult> AddOperation([FromBody] AddOperationCommand command, CancellationToken cancellationToken = default)
        {
            await Mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet("{operationId:int}")]
        public async Task<ActionResult<OperationResult>> GetById([FromRoute] int operationId, CancellationToken cancellationToken = default)
        {
            var query = new GetOperationDetailsQuery();
            query.SetOperationId(operationId);
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPut("{operationId:int}")]
        public async Task<ActionResult> UpdateOperation([FromRoute] int operationId, [FromBody] UpdateOperationCommand command,
            CancellationToken cancellationToken = default)
        {
            command.SetOperationId(operationId);
            await Mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
