using System;
using FluentValidation.Results;
using MediatR;

namespace Hydra.Core.Mediator.Messages
{
   public abstract class Command<TResponse> : Message, IRequest<CommandResult<TResponse>>
    {
        public DateTime TimeStamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

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