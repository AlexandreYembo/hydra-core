using System;
using Hydra.Core.Abstractions.Validations;

namespace Hydra.Core.Integration.Messages.VoucherMessages
{
    public class VoucherResponseMessage : ResponseMessage
    {
        public VoucherResponseMessage(string code, decimal? discount,
            int voucherType,  DateTime expirationDate, bool active, bool isUsed, IValidationResultAbstraction validationResult) 
        : base(validationResult)
        {
            Code = code;
            Discount = discount;
            VoucherType = voucherType;
            ExpirationDate = expirationDate;
            Active = active;
            IsUsed = isUsed;
        }

        public string Code { get; private set; }
        public decimal? Discount { get; private set; }
        public int VoucherType { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool Active { get; private set; }
        public bool IsUsed { get; private set; }
    }
}