using System.Threading.Tasks;
using Hydra.Core.Mediator.Abstractions.Mediator;
using Hydra.Core.Mediator.Integration;
using Hydra.Core.Mediator.Messages;
using MediatR;

namespace Hydra.Core.Mediator.Communication
{
    /// <summary>
    /// Wraper class that implements Mediator and will receive customization in the future.
    /// </summary>
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IDispatchLogEventToBus _dispatchEventLogToBus;
        public MediatorHandler(IMediator mediator,
                              IDispatchLogEventToBus dispatchEventLogToBus)
        {
            _mediator = mediator;
            _dispatchEventLogToBus = dispatchEventLogToBus;
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
            await _dispatchEventLogToBus.PublishEventIntegration(tEvent);
        }

        public async Task<CommandResult<TResponse>> SendCommand<T, TResponse>(T command) where T : Command<TResponse>
        {
            return await _mediator.Send(command);
        }

        public async Task SendCommand<T>(T command) where T : Command
        {
            await _mediator.Send(command);
        }
    }
}