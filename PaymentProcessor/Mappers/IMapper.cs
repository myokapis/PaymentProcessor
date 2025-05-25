using PaymentProcessor.Messages;
using PaymentProcessor.Transaction.Context;

namespace PaymentProcessor.Mappers
{
    public interface IMapper
    {
        IAccessibleMessage Map(ITransactionContext transactionContext);
        IAccessibleMessage SetFields(IAccessibleMessage message, Dictionary<string, object> fieldValues);
    }

    public interface IMapper<TContext> : IMapper
        where TContext : ITransactionContext
    {
        IAccessibleMessage Map(TContext transactionContext);
    }
}
