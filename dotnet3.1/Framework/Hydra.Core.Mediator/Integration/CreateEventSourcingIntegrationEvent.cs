using System;
namespace Hydra.Core.Mediator.Integration {
    public class CreateEventSourcingIntegrationEvent : IntegrationEvent
    {

        public CreateEventSourcingIntegrationEvent(Guid aggregateId, string msgType, string entity) {
            
            AggregateId = aggregateId;
            this.Entity = entity;
            MessageType = msgType;
        }
        public string Entity { get; set; }
    }
}