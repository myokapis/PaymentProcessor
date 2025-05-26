using PaymentProcessor.Transaction.Model;

namespace PaymentProcessor.Builders
{
    public interface IBuilder<T>
    {
        T Build(ITransactionModel transaction);
    }
}
