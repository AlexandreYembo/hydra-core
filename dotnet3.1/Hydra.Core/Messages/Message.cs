using System;

namespace Hydra.Core.Messages
{
    //base class
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        /// <summary>
        /// All command triggered has reference with Aggregation root
        /// </summary>
        /// <value></value>
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            //Return name of the class that it is implementing the message class.
            MessageType = GetType().Name;
        }
    }
}
