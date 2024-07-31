using Larmo.Domain.Domain;

namespace Larmo.Core.Application.Operations.OperationTypeLookUp;

public sealed record OperationTypeLookupResult(int Key, OperationType Value);