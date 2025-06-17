using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    public interface IBuilder<T>
    {
        T Build(ITransactionModel transaction);
    }
}
