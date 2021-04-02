using System.Collections.Generic;

namespace Hydra.Core.Mediator.Communication
{
  public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
    }
}