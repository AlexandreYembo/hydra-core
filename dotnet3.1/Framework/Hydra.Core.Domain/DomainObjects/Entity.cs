using System;
using System.Collections.Generic;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Domain.DomainObjects
{
   public abstract class Entity
    {
        public Guid Id {get;set;}

        /// <summary>
        /// This list is used when persist object to Database, it will submit the event to:
        /// 1- Could be a queue
        /// 2- Could persist in another database
        /// </summary>
        private List<Event> _notifications;

        public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// An Entity has an identity. For an entity be equals another entity, both might have the same type 
        /// and they need to have the same Id.
        /// It is necessary because we need to consider the entities as unique
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
             var compareTo = obj as Entity;

             if(ReferenceEquals(this, compareTo)) return true;
             if(ReferenceEquals(null, compareTo)) return false;

             return Id.Equals(compareTo.Id);
        }

        /// <summary>
        /// It is necessary because we need to consider the entities as unique
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if(ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if(ReferenceEquals(a, null) || ReferenceEquals(null, null)) return false;

            return a.Equals(b);
        }

        /// <summary>
        /// It is necessary because we need to consider the entities as unique
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Entity a, Entity b) => !(a == b);

        /// <summary>
        /// This event will be sent during the UnitofWork commit
        /// If the commit returns true, the event will triggered
        /// </summary>
        /// <param name="eventItem"></param>
        public void AddEvent(Event eventItem)
        {
            _notifications = _notifications ?? new List<Event>();
            _notifications.Add(eventItem);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notifications?.Remove(eventItem);
        }

        public void ClearEvents()
        {
            _notifications?.Clear();
        }

        /// <summary>
        /// Hashcode also is used to compare a class.false Exlusive code of an specific class.false
        /// This method overrides the virtual GetHashcode and its hash is mutiplicable to 907 + Id of HashCode, to garantee 
        /// that there won't have any hash with the same value, reducing the risk of have class with same hashcode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id = {Id}]";

        public abstract bool IsValid();
    }
}