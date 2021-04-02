using System;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Hydra.Core.Abstractions.Data;
using Hydra.Core.Domain.Queries;
using Hydra.Core.Example.Domain.Interfaces;
using Hydra.Core.Example.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Core.Example.Data.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly ExampleContext _context;


         public ExampleRepository(ExampleContext context){
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<PagedResult<ExampleData>> GetAll(int pageSize, int pageIndex, string query = null)
        {
            var sql = @$"SELECT * FROM Products 
                        WHERE (@Name IS NULL OR Name LIKE '%' + @Name + '%')
                        ORDER BY [Name]
                        OFFSET {pageSize * (pageIndex -1)} ROWS
                        FETCH NEXT {pageSize} ROWS ONLY
                        SELECT COUNT(Id) FROM Products
                        WHERE (@Name IS NULL OR Name LIKE '%' + @Name + '%')";
            
            var multi = await _context.Database.GetDbConnection()
                                               .QueryMultipleAsync(sql, new { Name = query});
            var products = multi.Read<ExampleData>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<ExampleData>()
            {
                List = products,
                TotalResult = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }

        public async Task<ExampleData> GetById(Guid id)
        {
            return await _context.ExampleData.FindAsync();
        }

        public void Insert(ExampleData entity)
        {
            _context.ExampleData.Add(entity);
        }

        public void Update(ExampleData entity)
        {
            _context.ExampleData.Update(entity);
        }
    }
}