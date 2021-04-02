using Hydra.Core.Abstractions.Validations;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Integration.Messages
{
    public class ResponseMessage : Message
    {
        public ResponseMessage(IValidationResultAbstraction validResult)
        {
            ValidResult = validResult;
        }

        public IValidationResultAbstraction ValidResult {get; set;}
    }
}