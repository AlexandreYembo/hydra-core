using System.Threading.Tasks;
using Hydra.Core.Messages;

namespace Hydra.Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T tEvent) where T : Event;
    }
}
