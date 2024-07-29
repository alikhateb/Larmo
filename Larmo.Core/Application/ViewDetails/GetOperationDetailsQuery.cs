using Larmo.Core.Application.ViewCollection;
using MediatR;

namespace Larmo.Core.Application.ViewDetails;

public sealed class GetOperationDetailsQuery : IRequest<OperationResult>
{
    private int _operationId;
    public void SetOperationId(int operationId) => _operationId = operationId;
    public int GetOperationId() => _operationId;
}