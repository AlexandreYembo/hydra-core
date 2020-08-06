using System;
using Hydra.Core.Messages;

namespace Hydra.Core.Messages.CommonMessages.DomainEvents
{
    /// <summary>
    /// Super class of Domain Event
    /// </summary>
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
