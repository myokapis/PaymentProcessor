using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Processor.Context
{
    public class ProcessContext : IProcessContext
    {
        public ProcessContext() // (Body transactionBody)
        {
            //Transaction = transactionBody;
        }

        public Card? Card { get; set; }
        public Envelope? Envelope { get; set; }
        public string? ProcessorResponse { get; set; }
        public IAccessibleMessage? RequestMessage { get; set; }
        public string? SerializedRequest { get; set; }
        public Body? Transaction { get; set; }
    }
}
