using FluentValidation.Results;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Mediator.Integration
{
    public class ResponseMessage : Message
    {
        public ResponseMessage(ValidationResult validResult)
        {
            ValidResult = validResult;
        }

        public ValidationResult ValidResult {get; set;}
    }
}