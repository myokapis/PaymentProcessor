using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Processor.Context;
using PaymentProcessor.Processor.ProcessStep;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Processor
{
    public class ProcessRunner : IProcessRunner
    {
        
        private readonly ProcessStepFactory processStepFactory;
        private bool isSuccessful;

        public ProcessRunner(ProcessStepFactory processStepFactory, IProcessContext processContext)
        {
            
            this.processStepFactory = processStepFactory;
            ProcessContext = processContext;
        }

        public IProcessContext ProcessContext { get; init; }

        public void Run(Body transaction)
        {
            isSuccessful = true;
            ProcessContext.Transaction = transaction;
            Steps();
        }

        public async Task RunAsync(Body transaction)
        {
            isSuccessful = true;
            ProcessContext.Transaction = transaction;
            await StepsAsync();
        }

        protected virtual void Steps()
        {
        }

        protected virtual async Task StepsAsync()
        {
        }

        protected void HandleException(Exception exception)
        {
            isSuccessful = false;
            // TODO: sanitize and log exception
        }

        protected void RunStep<T>() where T : IProcessStep
        {
            try
            {
                //var step = processStepFactory.GetProcessStep<T>();
                var step = processStepFactory(typeof(T));
                isSuccessful = isSuccessful && step.Run();
            }
            catch(Exception e)
            {
                HandleException(e);
            }
        }

        protected async Task RunStepAsync<T>() where T : IProcessStep, new()
        {
            try
            {
                //var step = processStepFactory.GetProcessStep<T>();
                var step = processStepFactory(typeof(T));
                var result = await step.RunAsync();
                isSuccessful = isSuccessful && result;
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }
    }
}
