using System;
using System.Collections.Generic;

namespace Hydra.Core.Integration.Messages
{
    public class CatalogIntegrationEvent : IntegrationEvent
    {
        public List<Guid> ProductIds { get; set; }
        
        public CatalogIntegrationEvent(List<Guid> productIds)
        {
            this.ProductIds = productIds;   
        }
    }
}