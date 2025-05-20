using System.Text;
using PaymentProcessor.Messages;

namespace PaymentProcessor.Serializers
{
    public interface IMessageSerializer
    {
        void SerializeMessage(IAccessibleMessage message, StringBuilder b, bool isMasked = false);
    }
}
