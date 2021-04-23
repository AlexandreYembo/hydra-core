using System.Threading.Tasks;

namespace Hydra.Core.Abstractions.Data
{
  public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}