using System;

namespace Hydra.Core.Integration.Messages.OrderMessages
{
    public class OrderInProcessingIntegrationEvent : IntegrationEvent
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }

        public OrderInProcessingIntegrationEvent(Guid customerId, Guid orderId)
        {
            CustomerId = customerId;
            OrderId = orderId;
        }
    }
}