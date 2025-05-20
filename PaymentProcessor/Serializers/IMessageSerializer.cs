using System.Text;
using PaymentProcessor.Requests.Messages;

namespace PaymentProcessor.Serializers
{
    public interface IMessageSerializer
    {
        void SerializeMessage(IAccessibleMessage message, StringBuilder b, bool isMasked = false);
    }
}
