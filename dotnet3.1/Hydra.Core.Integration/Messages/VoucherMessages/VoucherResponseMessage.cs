using System;
using FluentValidation.Results;

namespace Hydra.Core.Integration.Messages.VoucherMessages
{
    public class VoucherResponseMessage : ResponseMessage
    {
        public VoucherResponseMessage(string code, decimal? discount,
            VoucherType voucherType,  DateTime expirationDate, bool active, bool isUsed, ValidationResult validationResult) 
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
        public VoucherType VoucherType { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool Active { get; private set; }
        public bool IsUsed { get; private set; }
    }

     public enum VoucherType
    {
        Percentage = 0,
        Value = 1
    }
}