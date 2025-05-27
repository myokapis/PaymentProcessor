using PaymentProcessor.Messages;

namespace PaymentProcessor.Transaction.Context
{
    public class Envelope<T> : AccessibleMessage<T>, IEnvelope<T>
    {
        // TODO: add any envelope-specific behaviors
    }
}
