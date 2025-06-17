using System.Text;

namespace Payment.Messages.Serializers
{
    public interface IMessageSerializer
    {
        void SerializeMessage(IAccessibleMessage message, StringBuilder b, bool isMasked = false);
    }
}
