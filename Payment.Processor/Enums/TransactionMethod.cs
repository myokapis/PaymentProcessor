using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    public enum TransactionMethod
    {
        Unknown,

        [EnumMember(Value = "DIPPED")]
        Dipped,

        [EnumMember(Value = "KEYED")]
        Keyed,

        [EnumMember(Value = "QC_DIPPED")]
        QuickChip,

        [EnumMember(Value = "SWIPED")]
        Swiped,

        [EnumMember(Value = "SWIPED_FALLBACK")]
        SwipedFallback,

        [EnumMember(Value = "TAPPED")]
        Tapped,

        Token
    }
}
