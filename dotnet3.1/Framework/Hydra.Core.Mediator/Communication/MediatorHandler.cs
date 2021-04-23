using System.Threading.Tasks;
using Hydra.Core.Abstractions.Validations;
using Hydra.Core.Mediator.Communication.Abstractions.Mediator;
using Hydra.Core.Mediator.DomainEvents;
using Hydra.Core.Mediator.Messages;
using Hydra.Core.Mediator.Notification;
using MediatR;

namespace Hydra.Core.Mediator.Communication
{
    /// <summary>
    /// Wraper class that implements Mediator and will receive customization in the future.
    /// </summary>
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
        public async Task PublishEvent<T>(T tEvent) where T : Event
        {
            await _mediator.Publish(tEvent);
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

        public async Task<IValidationResultAbstraction> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}