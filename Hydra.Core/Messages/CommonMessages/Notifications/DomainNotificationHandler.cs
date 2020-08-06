using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Hydra.Core.Messages.CommonMessages.Notifications
{
    /// <summary>
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
    }
}