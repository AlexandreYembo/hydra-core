using System.Threading;
using System.Threading.Tasks;
using Hydra.Core.Example.Domain.Commands;
using Hydra.Core.Mediator.Abstractions.Mediator;
using MediatR;

namespace Hydra.Core.Example.Domain.Events.ExampleEvents
{
    public class ExampleEventHandler : 
            INotificationHandler<ExampleEvent>,
            INotificationHandler<ExampleEvent2>

    {
        private readonly IMediatorHandler _mediatorHandler;

        public ExampleEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(ExampleEvent notification, CancellationToken cancellationToken)
        {
            // You can Update a table with status false
            // you can send an email
            // you can dispatch another command to an external service

            await _mediatorHandler.SendCommand(new TestCommand2("test"));
        }

        public Task Handle(ExampleEvent2 notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}