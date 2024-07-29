using Larmo.Core.Paging;
using MediatR;

namespace Larmo.Core.Application.ViewCollection;

public sealed class GetOperationCollectionQuery : PageRequest, IRequest<PageResponse<OperationResult>>;