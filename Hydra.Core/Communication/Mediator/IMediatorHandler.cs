using System.Threading.Tasks;
using Hydra.Core.Messages;
using Hydra.Core.Messages.CommonMessages.Notifications;

namespace Hydra.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T tEvent) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
