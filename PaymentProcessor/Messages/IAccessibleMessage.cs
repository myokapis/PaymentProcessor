namespace PaymentProcessor.Messages
{
    public interface IAccessibleMessage
    {
        int FieldCount { get; }
        IEnumerable<FieldDefinition> FieldDefinitions { get; }
    }

    public interface IAccessibleMessage<T> : IAccessibleMessage
    {
    }
}
