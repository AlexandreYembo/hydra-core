using System;
using System.Text.Json;
using System.Threading.Tasks;
using Hydra.Core.Mediator.Integration;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.MessageBus.LogEventsIntegrations
{
    public class DispatchLogEventToBus : IDispatchLogEventToBus
    {
        private readonly IMessageBus _messageBus;

        public DispatchLogEventToBus(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task PublishEventIntegration<T>(T tEvent) where T : Event
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var json = JsonSerializer.Serialize<T>(tEvent, options);
            await _messageBus.PublishAsync(new CreateEventSourcingIntegrationEvent(tEvent.AggregateId, tEvent.MessageType, json));
                
        }
    }
}