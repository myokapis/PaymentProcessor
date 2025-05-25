using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Processor;
using TsysProcessor.Processor.Context;
using TsysProcessor.Processor.Transaction;
using TsysProcessor.Processor.TransactionSteps;

namespace TsysProcessor.Processor
{
    public class TsysTransactionRunner : ProcessRunner<TsysProcessContext>
    {
        public TsysTransactionRunner(ProcessStepFactory processStepFactory, TsysProcessContext processContext) :
            base(processStepFactory, processContext)
        {
        }

        protected override async Task StepsAsync()
        {
            // TODO: add steps here
            RunStep<BuildTransactionContext>();
            RunStep<BuildMessage>();
            RunStep<SerializeMessage>();

            // await RunStepAsync<SendMessage>();
        }
    }
}
