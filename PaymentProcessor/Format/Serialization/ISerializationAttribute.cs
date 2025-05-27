namespace PaymentProcessor.Format.Serialization
{
    public interface ISerializationAttribute
    {
        bool AlwaysTerminate { get; init; }
        bool Masked { get; init; }
        char MaskChar { get; init; }
        // TODO: decide if this is needed
        bool SuppressNull { get; init; }
        string? Terminator { get; init; }
    }
}
