using System;
using FluentValidation.Results;

namespace Hydra.Core.Mediator.Messages
{
    public class CommandResult<T>
    {
        public Guid TransactionId { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public T Payload {get; set;}

        public CommandResult(T payload)
        {
            Payload = payload;
            TransactionId = Guid.NewGuid();
        }

        public CommandResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
            TransactionId = Guid.NewGuid();
        }
    }
}