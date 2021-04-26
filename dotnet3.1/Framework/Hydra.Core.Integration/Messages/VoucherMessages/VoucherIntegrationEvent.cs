using System;
using Hydra.Core.Mediator.Integration;

namespace Hydra.Core.Integration.Messages.VoucherMessages
{
    public class VoucherIntegrationEvent: IntegrationEvent
    {
        public VoucherIntegrationEvent(string code)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}