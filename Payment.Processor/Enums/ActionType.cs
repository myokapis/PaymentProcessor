using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    public enum ActionType
    {
        None,

        [EnumMember(Value = "Auto_Void")]
        AutoVoid,

        [EnumMember(Value = "Balance_Inquiry")]
        BalanceInquiry,

        Capture,

        [EnumMember(Value = "Card_Authentication")]
        CardAuth,

        [EnumMember(Value = "Partial_Reversal")]
        PartialReversal,

        [EnumMember(Value = "Pre_Auth")]
        PreAuth,

        Return,
        Sale,

        [EnumMember(Value = "Timeout_Reversal")]
        TimeoutReversal,

        Void
    }
}
