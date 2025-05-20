using PaymentProcessor.Processor.Context;

namespace PaymentProcessor.Processor.ProcessStep
{
    public interface IProcessStep
    {
        IProcessContext ProcessContext { get; init; }
        bool Run() => throw new NotImplementedException();
        Task<bool> RunAsync() => throw new NotImplementedException();
    }
}
