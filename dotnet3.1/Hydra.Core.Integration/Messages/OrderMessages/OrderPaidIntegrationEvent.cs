using System;

namespace Hydra.Core.Integration.Messages.OrderMessages
{
    public class OrderPaidIntegrationEvent: IntegrationEvent
    {
        public OrderPaidIntegrationEvent(Guid customerId, Guid orderId)
        {
            CustomerId = customerId;
            OrderId = orderId;
        }

        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
    }
}