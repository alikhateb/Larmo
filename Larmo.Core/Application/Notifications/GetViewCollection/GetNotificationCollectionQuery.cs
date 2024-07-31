using Larmo.Core.Paging;
using MediatR;

namespace Larmo.Core.Application.Notifications.GetViewCollection;

public class GetNotificationCollectionQuery : PageRequest, IRequest<PageResponse<NotificationResult>>;