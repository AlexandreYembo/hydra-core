using System;

namespace Hydra.Core.Integration.Messages.VoucherMessages
{
    public class VoucherIntegrationEvent: IntegrationEvent
    {
        public VoucherIntegrationEvent(string code)
        {
            Code = code;
        }

        public VoucherIntegrationEvent(Guid id)
        {
            Id = id;
        }
        public string Code { get; private set; }
        public Guid Id { get; private set; }
    }
}