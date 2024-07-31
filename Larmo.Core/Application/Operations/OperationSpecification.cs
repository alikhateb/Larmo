using Ardalis.Specification;
using Larmo.Domain.Domain;

namespace Larmo.Core.Application.Operations;

public sealed class OperationSpecification : Specification<Operation>
{
    public OperationSpecification()
    {
    }

    public OperationSpecification(int operationId)
    {
        Query.Where(o => o.Id == operationId);
    }
}