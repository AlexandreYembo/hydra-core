using System;
using System.Threading.Tasks;
using Hydra.Core.Abstractions.Data;
using Hydra.Core.Abstractions.Data.Queries;
using Hydra.Core.Example.Domain.Models;

namespace Hydra.Core.Example.Domain.Interfaces
{
    public interface IExampleRepository :  IRepository<ExampleEntity>
    {
        Task<PagedResult<ExampleEntity>> GetAll(int pageSize, int pageIndex, string query = null);
        Task<ExampleEntity> GetById(Guid id);

        void Insert(ExampleEntity entity);
        void Update(ExampleEntity entity);
    }
}