using Ardalis.Specification;
using Larmo.Domain.Domain;

namespace Larmo.Core.Application.Notifications;

public sealed class NotificationSpecification : Specification<Notification>
{
    public NotificationSpecification()
    {
    }

    public NotificationSpecification(int notificationId)
    {
        Query.Where(o => o.Id == notificationId);
    }
}