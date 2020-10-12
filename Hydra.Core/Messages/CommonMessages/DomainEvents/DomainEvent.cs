using System;
using Hydra.Core.Messages;
using MediatR;

namespace Hydra.Core.Messages.CommonMessages.DomainEvents
{
    /// <summary>
    /// Super class of Domain Event
    /// </summary>
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
        }
    }
}
