using Hydra.Core.Mediator.Messages;
using Hydra.Core.Validator;

namespace Hydra.Core.Mediator.Integration
{
    public class ResponseMessage : Message
    {
        public ResponseMessage(IValidationResult validResult)
        {
            ValidResult = validResult;
        }

        public IValidationResult ValidResult {get; set;}
    }
}