using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    public enum CardBrand
    {
        Unknown,

        [EnumMember(Value = "AMEX")]
        Amex,

        [EnumMember(Value = "DINERS_CLUB")]
        DinersClub,

        [EnumMember(Value = "DISCOVER")]
        Discover,

        [EnumMember(Value = "JCB")]
        JCB,

        [EnumMember(Value = "MASTER_CARD")]
        MasterCard,

        [EnumMember(Value = "UNION_PAY")]
        UnionPay,

        [EnumMember(Value = "VISA")]
        Visa
    }
}
