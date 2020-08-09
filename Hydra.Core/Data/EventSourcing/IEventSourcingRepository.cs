using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hydra.Core.Messages;

namespace Hydra.Core.Data.EventSourcing
{
    public interface IEventSourcingRepository
    {
         Task SaveEvent<TEvent>(TEvent tEvent) where TEvent : Event;
         Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId);
    }
}