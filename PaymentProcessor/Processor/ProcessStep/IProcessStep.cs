using PaymentProcessor.Processor.Context;
using PaymentProcessor.Transaction.Context;
using PaymentProcessor.Transaction.Model;

namespace PaymentProcessor.Processor.ProcessStep
{
    public interface IProcessStep<TContext> : IProcessStep
    {
        new TContext ProcessContext { get; init; }
    }

    public interface IProcessStep
    {
        IProcessContext ProcessContext { get; init; }
        bool Run();
        Task<bool> RunAsync();
    }
}
