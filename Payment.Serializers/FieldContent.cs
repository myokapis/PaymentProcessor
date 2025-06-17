using PaymentProcessor.Format.Attributes;
using PaymentProcessor.Format.Serialization;

namespace Payment.Serializers
{
    public class FieldContent
    {
        public required string FieldName { get; init; }
        public IFormatAttribute? FormatAttribute { get; init; }
        public ISerializationAttribute? SerializationAttribute { get; init; }
        public object? Value { get; init; }
    }
}
