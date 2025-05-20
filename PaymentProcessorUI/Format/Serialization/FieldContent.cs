using PaymentProcessor.Format.Attributes;
using PaymentProcessor.Format.Serialization;

namespace PaymentProcessor.Format.Serialization
{
    public class FieldContent
    {
        public required string FieldName { get; init; }
        public FormatAttribute? FormatAttribute { get; init; }
        public SerializationAttribute? SerializationAttribute { get; init; }
        public object? Value { get; init; }
    }
}
