namespace PaymentProcessor.Format.Serialization
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SerializationAttribute : Attribute
    {
        public SerializationAttribute()
        {
        }

        public bool AlwaysTerminate { get; init; } = true;
        public bool Masked { get; init; } = false;
        public char MaskChar { get; init; } = '*';
        // TODO: decide if this is needed
        public bool SuppressNull { get; init; } = false;
        public string? Terminator { get; init; }
    }
}
