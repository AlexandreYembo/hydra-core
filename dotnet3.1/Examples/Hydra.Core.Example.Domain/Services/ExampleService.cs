using Hydra.Core.Domain.Abstractions.Mediator;
using Hydra.Core.Example.Domain.Models;

namespace Hydra.Core.Example.Domain.Services
{
    public class ExampleService
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ExampleService(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        // public void Save(ExampleEntity entity)
        // {
        //     if(!entity.IsValid())
        //     {
        //         // if(entity.HasNotStock())
        //         // {
        //         //        _mediatorHandler.PublishDomainEvent(new ProductAllowStockEvent(entity.Id, entity.Quantity));
        //         // }
        //     }
        // }
    }
}