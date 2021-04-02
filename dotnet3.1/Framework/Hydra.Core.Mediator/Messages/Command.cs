using System;
using Hydra.Core.Abstractions.Validations;
using MediatR;

namespace Hydra.Core.Mediator.Messages
{
   public abstract class Command : Message, IRequest<IValidationResultAbstraction>
    {
        public DateTime TimeStamp { get; private set; }
        public IValidationResultAbstraction ValidationResult { get; set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}