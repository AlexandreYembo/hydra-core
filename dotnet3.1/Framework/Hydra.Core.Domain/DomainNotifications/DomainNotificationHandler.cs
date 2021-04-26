using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hydra.Core.Domain.DomainNotifications;
using MediatR;

namespace Hydra.Core.Mediator.Notification
{
    /// It will return a list of notification type of DomainNotification
    /// </summary>
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }
        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications() => _notifications;

        public virtual bool HasNotification() => _notifications.Any();
    }
}