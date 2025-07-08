using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    public enum Platform
    {
        Unknown,

        [EnumMember(Value = "android")]
        Android,

        [EnumMember(Value = "iOS")]
        Apple,

        [EnumMember(Value = "scheduled_payment")]
        ScheduledPayment,

        // NOTE: valid value that we should not see in this app
        [EnumMember(Value = "terminal")]
        Terminal,

        [EnumMember(Value = "virtual_terminal")]
        VirtualTerminal
    }
}
