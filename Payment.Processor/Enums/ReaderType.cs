using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    // TODO: remove any reader types that will never come through this app 
    public enum ReaderType
    {
        UNKNOWN,

        [EnumMember(Value = "A250")]
        A250,

        [EnumMember(Value = "B200")]
        B200,

        [EnumMember(Value = "B250")]
        B250,

        [EnumMember(Value = "B350")]
        B350,

        [EnumMember(Value = "B500")]
        B500,

        [EnumMember(Value = "BTMAG")]
        BTMAG,

        [EnumMember(Value = "")]
        IDTECH,

        [EnumMember(Value = "")]
        M010,

        [EnumMember(Value = "NO_READER")]
        NO_READER,

        [EnumMember(Value = "")]
        RAMBLER,

        [EnumMember(Value = "UNENCRYPTED")]
        UNENCRYPTED,

        [EnumMember(Value = "")]
        WALKER
    }
}
