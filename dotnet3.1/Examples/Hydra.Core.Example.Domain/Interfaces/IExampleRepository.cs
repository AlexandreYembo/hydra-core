using System;
using System.Threading.Tasks;
using Hydra.Core.Abstractions.Data;
using Hydra.Core.Domain.Queries;
using Hydra.Core.Example.Domain.Models;

namespace Hydra.Core.Example.Domain.Interfaces
{
    public interface IExampleRepository :  IRepository<ExampleData>
    {
        Task<PagedResult<ExampleData>> GetAll(int pageSize, int pageIndex, string query = null);
        Task<ExampleData> GetById(Guid id);

        void Insert(ExampleData entity);
        void Update(ExampleData entity);
    }
}