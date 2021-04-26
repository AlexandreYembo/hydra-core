using System;
using Hydra.Core.Abstractions.DomainObjects;
using Hydra.Core.Domain.DomainEvents;
using Hydra.Core.Domain.DomainNotifications;
using Hydra.Core.Domain.DomainObjects;
using Hydra.Core.Example.Domain.Events.ExampleEvents;

namespace Hydra.Core.Example.Domain.Models
{
   public class ExampleEntity : Entity, IAggregateRoot 
    {
        public ExampleEntity(Guid id, string name, int quantity, bool active)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Active = active;
        }

        public string Name { get; protected set; }

        public int Quantity {get; protected set;}
        public bool Active {get; protected set;}

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) || Quantity < 1 || Active == false;
        }

        internal bool HasNotStock()
        {
            return Quantity < 1;
        }

        internal DomainNotification InvalidNameNotification()
        {
            return new DomainNotification("ExampleEntity", "Name  is not valid");
        }
    }
}