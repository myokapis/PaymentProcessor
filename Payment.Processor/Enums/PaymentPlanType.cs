using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    public enum PaymentPlanType
    {
        None,

        [EnumMember(Value = "SINGLE")]
        OneTime,

        [EnumMember(Value = "INSTALLMENT")]
        Installment,

        [EnumMember(Value = "RECURRING")]
        Recurring
    }
}
