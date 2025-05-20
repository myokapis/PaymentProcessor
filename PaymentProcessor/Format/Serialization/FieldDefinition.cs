using System.Reflection;
using PaymentProcessor.Format.Attributes;

namespace PaymentProcessor.Format.Serialization
{
    public readonly struct FieldDefinition
    {
        public PropertyInfo PropertyInfo { get; init; }
        public FormatAttribute? FormatAttribute { get; init; }
        public SerializationAttribute? SerializationAttribute { get; init; }
    }
}
