using System;

namespace Hydra.Core.Integration.Messages
{
    /// <summary>
    /// Class used to comunicate across multiple apis via integration and Queue
    /// </summary>
    public class RegisteredUserIntegrationEvent : IntegrationEvent
    {
        public RegisteredUserIntegrationEvent(Guid id, string name, string email, string identityNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            IdentityNumber = identityNumber;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string IdentityNumber { get; private set; }
    }
}