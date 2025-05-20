using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers
{
    public interface IMapper
    {
        IAccessibleMessage Map(Body transaction);
        IAccessibleMessage SetFields(IAccessibleMessage message, Dictionary<string, object> fieldValues);
    }
}
