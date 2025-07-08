using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    public interface IBuilder<T>
    {
        // TODO: should T be nullable?
        T Build(ITransactionModel transaction) => throw new NotImplementedException();
        T Build<TContext>(ITransactionModel transaction, TContext context) => throw new NotImplementedException();
    }
}
