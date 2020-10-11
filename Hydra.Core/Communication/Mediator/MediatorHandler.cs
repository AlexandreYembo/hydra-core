using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using Hydra.Core.Data.EventSourcing;
using Hydra.Core.Messages;
using Hydra.Core.Messages.CommonMessages.DomainEvents;
using Hydra.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Hydra.Core.Communication.Mediator
{
    /// <summary>
    /// Wraper class that implements Mediator and will receive customization in the future.
    /// </summary>
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventSourcingRepository _eventSourcingRepository;
        private readonly IConfiguration _configuration;


        public MediatorHandler(IMediator mediator, IEventSourcingRepository eventSourcingRepository, IConfiguration configuration)
        {
            _mediator = mediator;
            _eventSourcingRepository = eventSourcingRepository;
            _configuration = configuration;
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

            var eventSourcingEnabled = Boolean.Parse(_configuration.GetSection("EnableEventSourcing").Value);
            
            if(eventSourcingEnabled)
                await _eventSourcingRepository.SaveEvent(tEvent);
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

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
