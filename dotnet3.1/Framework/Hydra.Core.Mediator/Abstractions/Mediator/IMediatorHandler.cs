using System.Threading.Tasks;
using Hydra.Core.Abstractions.Validations;
using Hydra.Core.Mediator.DomainEvents;
using Hydra.Core.Mediator.Messages;
using Hydra.Core.Mediator.Notification;

namespace Hydra.Core.Mediator.Communication.Abstractions.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T tEvent) where T : Event;
        Task PublishDomainEvent<T>(T tEvent) where T : DomainEvent;
        Task<IValidationResultAbstraction> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}