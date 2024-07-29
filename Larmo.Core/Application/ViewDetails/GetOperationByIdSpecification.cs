using Ardalis.Specification;
using Larmo.Domain.Domain;

namespace Larmo.Core.Application.ViewDetails;

internal sealed class GetOperationByIdSpecification : Specification<Operation>
{
    public GetOperationByIdSpecification(int operationId)
    {
        Query.Where(o => o.Id == operationId);
    }
}