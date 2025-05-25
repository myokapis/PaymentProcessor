using PaymentProcessor.Processor.Context;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;

namespace TsysProcessor.Processor.Context
{
    public class TsysProcessContext : ProcessContext<TsysTransaction, TsysTransactionContext>
    {
    }
}
