using System.Text.Json.Serialization;

namespace PaymentProcessor.Transaction
{
    public class Body
    {
        [JsonPropertyName("transaction_details")]
        public required Details Details { get; init; }

        public required Merchant Merchant { get; init; }

        [JsonPropertyName("merchant_account_specific")]
        public required ProcessorAttributes ProcessorAttributes { get; init; }
    }
}
