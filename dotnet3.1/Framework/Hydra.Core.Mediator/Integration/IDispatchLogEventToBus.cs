using System.Threading.Tasks;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Mediator.Integration
{
    public interface IDispatchLogEventToBus
    {
         Task PublishEventIntegration<T>(T tEvent) where T: Event;
    }
}