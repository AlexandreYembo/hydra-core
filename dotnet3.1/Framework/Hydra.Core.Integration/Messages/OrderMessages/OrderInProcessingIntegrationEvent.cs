using System;
using Hydra.Core.Mediator.Integration;

namespace Hydra.Core.Integration.Messages.OrderMessages
{
    public class OrderInProcessingIntegrationEvent : IntegrationEvent
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public int PaymentType { get; set; }
        public decimal Price { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
    }
}