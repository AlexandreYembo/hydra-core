using System.Threading.Tasks;
using Hydra.Core.Abstractions.Data.Queries;
using Hydra.Core.Example.Domain.Models;

namespace Hydra.Core.Example.Data.Query
{
    public interface IMyQueryRepository
    {
        Task<PagedResult<ExampleEntity>> GetAllProducts(int pageSize, int pageIndex, string query = null);
    }
    public class MyQueryRepository : IMyQueryRepository
    {
        private readonly IQueryRepository _queryRepository;

        public MyQueryRepository(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<PagedResult<ExampleEntity>> GetAllProducts(int pageSize, int pageIndex, string query = null)
        {
            var sql = @$"SELECT * FROM Products 
                    WHERE (@Name IS NULL OR Name LIKE '%' + @Name + '%')
                    ORDER BY [Name]
                    OFFSET {pageSize * (pageIndex -1)} ROWS
                    FETCH NEXT {pageSize} ROWS ONLY
                    SELECT COUNT(Id) FROM Products
                    WHERE (@Name IS NULL OR Name LIKE '%' + @Name + '%')";
            return await _queryRepository.GetAsync<ExampleEntity>(pageSize, pageIndex, sql, query);            
        }
    }
}