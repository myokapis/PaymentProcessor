using PaymentProcessor.Format.Serialization;

namespace PaymentProcessor.Requests.Messages
{
    public interface IAccessibleMessage: IMessage, IAccessible
    {
    }

    public interface IAccessibleMessage<T> : IAccessibleMessage
    {
    }
}
