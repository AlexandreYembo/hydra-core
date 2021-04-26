using System.Linq;
using System.Threading.Tasks;
using Hydra.Core.Data.Context;
using Hydra.Core.Domain.DomainObjects;
using Hydra.Core.Mediator.Abstractions.Mediator;

namespace Hydra.Core.Data.Extensions
{
    public static class MediatorExtension
    {
        /// <summary>
        /// This extension will publish the event after the commit of Unit of Work is sucessfull
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="ctx"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T ctx) where T : HydraDbContext
        {
            var domainEntities =  ctx.ChangeTracker
                    .Entries<Entity>()
                    .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                    .SelectMany(x => x.Entity.Notifications)
                    .ToList();

            domainEntities.ToList()
                    .ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents
                    .Select(async (domainEvent) => await mediator.PublishEvent(domainEvent));
            
            await Task.WhenAll(tasks);
        }
    }
}