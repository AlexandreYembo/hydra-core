using System.Threading.Tasks;
using FluentValidation.Results;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Mediator.Abstractions.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T tEvent) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}