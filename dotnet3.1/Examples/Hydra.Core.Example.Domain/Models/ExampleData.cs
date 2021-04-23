using Hydra.Core.Abstractions.DomainObjects;
using Hydra.Core.Domain.DomainObjects;

namespace Hydra.Core.Example.Domain.Models
{
   public class ExampleData : Entity, IAggregateRoot 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}