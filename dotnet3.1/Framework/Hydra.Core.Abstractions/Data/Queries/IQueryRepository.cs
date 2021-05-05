using System;
using System.Threading.Tasks;

namespace Hydra.Core.Abstractions.Data.Queries
{
    public interface IQueryRepository : IDisposable
    {
        Task<PagedResult<T>> GetAsync<T>(int pageSize, int pageIndex, string sqlQuery, string query = null) where T : class;
    }
}