using FluentValidation.Results;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Integration.Messages
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