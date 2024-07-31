using MediatR;

namespace Larmo.Core.Application.Operations.OperationTypeLookUp;

public sealed class OperationTypeLookupQuery : IRequest<OperationTypeLookupResult[]>;