using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Processor;
using PaymentProcessor.Processor.Context;
using TsysProcessor.Processor.Transaction;

namespace TsysProcessor.Processor
{
    public class TransactionRunner : ProcessRunner
    {
        public TransactionRunner(ProcessStepFactory processStepFactory, IProcessContext processContext) : base(processStepFactory, processContext)
        {
        }

        protected override async Task StepsAsync()
        {
            // TODO: add steps here
            // example:
            RunStep<BuildMessageStep>();
            RunStep<SerializeMessageStep>();
        }
    }
}
