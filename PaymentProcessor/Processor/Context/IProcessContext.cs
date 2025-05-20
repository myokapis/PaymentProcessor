using PaymentProcessor.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Processor.Context
{
    public interface IProcessContext
    {
        Card? Card { get; set; }
        Envelope? Envelope { get; set; }
        string? ProcessorResponse { get; set; }
        IAccessibleMessage? RequestMessage { get; set; }
        string? SerializedRequest { get; set; }
        Body? Transaction { get; set; }
    }
}
