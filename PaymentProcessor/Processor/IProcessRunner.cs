using PaymentProcessor.Processor.Context;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Processor
{
    public interface IProcessRunner
    {
        IProcessContext ProcessContext { get; init; }
        void Run(Body transaction) => throw new NotImplementedException();
        Task RunAsync(Body transaction) => throw new NotImplementedException();
    }
}
