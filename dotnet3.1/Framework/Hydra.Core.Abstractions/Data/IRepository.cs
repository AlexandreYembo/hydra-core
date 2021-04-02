using System;
using Hydra.Core.Abstractions.DomainObjects;

namespace Hydra.Core.Abstractions.Data
{
   public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}