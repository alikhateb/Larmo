using Larmo.Core.Repository;
using Larmo.Domain.Domain;
using Larmo.Infrastructure.Context;

namespace Larmo.Infrastructure.Repository;

public class NotificationRepository(BaseContext context) : Repository<Notification>(context), INotificationRepository;