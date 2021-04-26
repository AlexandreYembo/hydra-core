using System;
using Hydra.Core.Mediator.Integration;

namespace Hydra.Core.Integration.Messages.OrderMessages
{
    public class OrderItemRemovedFromStockIntegrationEvent : IntegrationEvent
    {
        public OrderItemRemovedFromStockIntegrationEvent(Guid customerId, Guid orderId)
        {
            CustomerId = customerId;
            OrderId = orderId;
        }

        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
    }
}