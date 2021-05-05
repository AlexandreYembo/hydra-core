using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hydra.Core.Abstractions.Data;
using Hydra.Core.Data.Extensions;
using Hydra.Core.Mediator.Abstractions.Mediator;
using Hydra.Core.Mediator.Messages;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Core.Data.Context
{

    public abstract class HydraDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public HydraDbContext(DbContextOptions options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)"); // avoid do create any column NVarchar(MAX)

            modelBuilder.Ignore<ValidationResult>();
            //Use to Ignore event to persist on Database.
            modelBuilder.Ignore<Event>();

            base.OnModelCreating(modelBuilder);
        }
        
        public virtual async Task<bool> Commit()
        {
             //ChangeTracker -> EF: change mapper
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if(entry.State == EntityState.Added)
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                
                if(entry.State == EntityState.Modified)
                    entry.Property("CreatedDate").IsModified = false;   //Ignore to update any value set for the property = "CreatedDate"
            }

            var success = await base.SaveChangesAsync() > 0;
            if(success)
                await _mediatorHandler.PublishEvents(this); //Call the mediator extension to publish the events

            return success;
        }
    }
}