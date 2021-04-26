using System.Threading;
using System.Threading.Tasks;
using Hydra.Core.Domain.Abstractions.Mediator;
using MediatR;

namespace Hydra.Core.Example.Domain.Events.ExampleEvents
{
    public class ExampleEventHandler :
            INotificationHandler<ProductAllowStockEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ExampleEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task Handle(ProductAllowStockEvent notification, CancellationToken cancellationToken)
        {
            // You can Update a table with status false
            // you can send an email
            // you can dispatch another command to an external service
            return Task.CompletedTask;
        }
    }
}