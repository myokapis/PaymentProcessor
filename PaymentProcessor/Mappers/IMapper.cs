using PaymentProcessor.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Mappers
{
    public interface IMapper
    {
        IAccessibleMessage Map(Body transaction);
        IAccessibleMessage SetFields(IAccessibleMessage message, Dictionary<string, object> fieldValues);
    }
}
