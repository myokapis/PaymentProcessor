using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    public enum DataSource
    {
        Unknown,

        [EnumMember(Value = "APPLICATION")]
        Application,

        [EnumMember(Value = "MOBILE_DEVICE")]
        MobileDevice,

        [EnumMember(Value = "READER")]
        Reader
    }
}
