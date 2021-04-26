using System.Threading.Tasks;
using Hydra.Core.Domain.DomainEvents;
using Hydra.Core.Domain.DomainNotifications;

namespace Hydra.Core.Domain.Abstractions.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishDomainEvent<T>(T tEvent) where T : DomainEvent;

        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}