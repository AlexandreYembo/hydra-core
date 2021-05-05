using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Hydra.Core.Abstractions.Data.Queries;
using Hydra.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Core.Data.Query
{
    public class QueryRepository : IQueryRepository
    {
        private readonly HydraDbContext _context;

        public QueryRepository(HydraDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<T>> GetAsync<T>(int pageSize, int pageIndex, string sqlQuery, string query = null) where T : class
        {
          var multi = await _context.Database.GetDbConnection()
                                             .QueryMultipleAsync(sqlQuery, new { Name = query});

            var result = multi.Read<T>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<T>()
            {
                List = result,
                TotalResult = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}