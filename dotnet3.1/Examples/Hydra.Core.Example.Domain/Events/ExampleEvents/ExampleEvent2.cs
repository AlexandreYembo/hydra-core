using System;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Example.Domain.Events.ExampleEvents
{
    public class ExampleEvent2: Event
    {
        public Guid Id { get; set; }

        public ExampleEvent2(Guid id)
        {
            Id = id;
        }
    }
}