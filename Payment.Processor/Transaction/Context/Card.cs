namespace Payment.Processor.Transaction.Context
{
    public class Card
    {
        public Card()
        { }

        public string? Address { get; init; }
        public string? CardType { get; init; }
        public string? CVV { get; init; }
        public required string DataSource { get; init; }
        public bool EMV { get; init; }
        public string? ExpirationMonth { get; init; }
        public string? ExpirationYear { get; init; }
        public bool Keyed { get; init; }
        public string? Name { get; init; }
        public string? Number { get; init; }
        public string? ReversalTLV { get; init; }
        public string? ServiceCode { get; init; }
        public bool Swiped { get; init; }
        public string? TLV { get; init; }
        public string? Track1 { get; init; }
        public string? Track2 { get; init; }
        public required string TransactionMethod { get; init; }
        public string? ZipCode { get; init; }
    }
}
