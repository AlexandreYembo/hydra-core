using System;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Example.Domain.Events.ExampleEvents
{
    public class ExampleEvent: Event
    {
        public Guid Id { get; set; }

        public ExampleEvent(Guid id)
        {
            Id = id;
        }
    }

    public class ExampleEventWithLog : Event
    {
        public string TestName { get; set; }

        public ExampleEventWithLog(string testName)
        {
            AggregateId = Guid.NewGuid();
            TestName = testName;
        }
    }
}