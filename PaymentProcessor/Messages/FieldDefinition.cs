using System.Reflection;
using PaymentProcessor.Format.Attributes;
using PaymentProcessor.Format.Serialization;

namespace PaymentProcessor.Messages
{
    public readonly struct FieldDefinition
    {
        public PropertyInfo PropertyInfo { get; init; }
        public IFormatAttribute? FormatAttribute { get; init; }
        public ISerializationAttribute? SerializationAttribute { get; init; }
    }
}
