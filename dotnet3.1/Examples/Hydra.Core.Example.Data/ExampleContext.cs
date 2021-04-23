using Hydra.Core.Data.Context;
using Hydra.Core.Example.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Core.Example.Data
{
    public class ExampleContext: HydraDbContext
    {
        //It is a kind of factory that will be configure the context on Startup.cs
        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options, null){ }

        public DbSet<ExampleData> ExampleData {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                //Does not need to add map for each element, new EF supports
                //It will find all entities and mapping defined on DbSet<TEntity> via reflection
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}