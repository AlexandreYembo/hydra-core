using System;

namespace Hydra.Core.Integration.Messages
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