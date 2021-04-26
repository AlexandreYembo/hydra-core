using System;
using Hydra.Core.Domain.DomainEvents;

namespace Hydra.Core.Example.Domain.Events.ExampleEvents
{
    public class ProductAllowStockEvent : DomainEvent
    {
        public ProductAllowStockEvent(Guid id, int quantity): base(id)
        {
            Id = id;
            Quantity = quantity;
        }

        public Guid Id { get; private set; }
        public int Quantity {get; private set; }
    }
}