using System.Text.Json;
using System.Threading.Tasks;
using Hydra.Core.Mediator.Integration;
using Hydra.Core.Mediator.Messages;
using Newtonsoft.Json;

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
            var json = JsonConvert.SerializeObject(tEvent);
            await _messageBus.PublishAsync(new CreateEventSourcingIntegrationEvent(tEvent.AggregateId, tEvent.MessageType, json));
        }
    }
}