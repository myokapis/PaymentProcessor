using Payment.Messages;

namespace Payment.Processor.Transaction.Context
{
    public interface IEnvelope<T> : IEnvelope, IAccessibleMessage<T>
    { }

    public interface IEnvelope
    {
        // TODO: add any envelope-specific behaviors
    }
}
