using System.Threading.Tasks;
using FluentValidation.Results;
using Hydra.Core.Messages;
using Hydra.Core.Messages.CommonMessages.DomainEvents;
using Hydra.Core.Messages.CommonMessages.Notifications;

namespace Hydra.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T tEvent) where T : Event;
        Task PublishDomainEvent<T>(T tEvent) where T : DomainEvent;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
