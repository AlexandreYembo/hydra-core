using System;
using Hydra.Core.Messages;

namespace Hydra.Core.DomainObjects
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
