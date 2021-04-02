using System;
using Hydra.Core.Mediator.Messages;
using MediatR;

namespace Hydra.Core.Mediator.Notification
{
    //This class is not used for Event root, but it has same inherance of Message and INotification that are present in Event.cs
    public class DomainNotification : Message, INotification
    {
         public DateTime Timestamp { get; private set; }
         public Guid DomainNotificationId { get; private set; }
         public string Key { get; private set; }
         public string Value { get; private set; }
         public int Version { get; private set; }

         public DomainNotification(string key, string value)
         {
             Timestamp = DateTime.Now;
             DomainNotificationId = Guid.NewGuid();
             Version = 1;
             Key = key;
             Value = value;
         }
    }
}