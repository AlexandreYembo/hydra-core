using System.Threading.Tasks;
using Hydra.Core.Abstractions.Validations;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Mediator.Abstractions.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T tEvent) where T : Event;
        Task<IValidationResultAbstraction> SendCommand<T>(T command) where T : Command;
    }
}