using FluentValidation.Results;
using Hydra.Core.Messages;

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