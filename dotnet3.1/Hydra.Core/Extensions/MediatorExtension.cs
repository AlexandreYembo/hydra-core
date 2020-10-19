using System.Linq;
using System.Threading.Tasks;
using Hydra.Core.Communication.Mediator;
using Hydra.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Core.Extensions
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
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
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