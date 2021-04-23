using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hydra.Core.EventSourcing.Models;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.EventSourcing
{
    public interface IEventSourcingRepository
    {
         Task SaveEvent<TEvent>(TEvent tEvent) where TEvent : Event;
         Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId);
    }
}