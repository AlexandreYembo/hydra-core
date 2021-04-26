using System;
using System.Collections.Generic;
using Hydra.Core.Mediator.Integration;

namespace Hydra.Core.Integration.Messages.OrderMessages
{
    public class OrderAuthorizedIntegrationEvent : IntegrationEvent
    {
        public OrderAuthorizedIntegrationEvent(Guid customerId, Guid orderId, IDictionary<Guid, int> items)
        {
            CustomerId = customerId;
            OrderId = orderId;
            Items = items;
        }

        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public IDictionary<Guid, int> Items { get; private set; }
    }
}