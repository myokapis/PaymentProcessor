using PaymentProcessor.Processor.Context;
using PaymentProcessor.Transaction.Model;

namespace PaymentProcessor.Processor
{
    public interface IProcessRunner
    {
        IProcessContext ProcessContext { get; init; }
        bool Run(ITransactionModel transaction);
        Task<bool> RunAsync(ITransactionModel transaction);
    }

    public interface IProcessRunner<TContext> : IProcessRunner
        where TContext : IProcessContext
    {
        new TContext ProcessContext { get; init; }
    }
}
