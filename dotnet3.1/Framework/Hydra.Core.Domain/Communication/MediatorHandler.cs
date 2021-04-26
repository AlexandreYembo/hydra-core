using System.Threading.Tasks;
using Hydra.Core.Domain.Abstractions.Mediator;
using Hydra.Core.Domain.DomainEvents;
using Hydra.Core.Domain.DomainNotifications;
using MediatR;

namespace Hydra.Core.Domain.Communication
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Will publish an event
        /// </summary>
        /// <param name="tEvent"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task PublishDomainEvent<T>(T tEvent) where T : DomainEvent
        {
            await _mediator.Publish(tEvent);
        } 

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }
    }
}