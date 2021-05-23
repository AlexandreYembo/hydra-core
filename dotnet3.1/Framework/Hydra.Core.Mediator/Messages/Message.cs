using System;

namespace Hydra.Core.Mediator.Messages
{
    //base class
    public abstract class Message
    {
        public string MessageType { get; set; }
        /// <summary>
        /// All command triggered has reference with Aggregation root
        /// </summary>
        /// <value></value>
        public Guid AggregateId { get; set; }

        protected Message()
        {
            //Return name of the class that it is implementing the message class.
            MessageType = GetType().Name;
        }
    }
}