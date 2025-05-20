using PaymentProcessor.Format.Serialization;

namespace PaymentProcessor.Messages
{
    public interface IAccessibleMessage: IMessage, IAccessible
    {
    }

    public interface IAccessibleMessage<T> : IAccessibleMessage
    {
    }
}
