using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Processor.Context;
using PaymentProcessor.Processor.ProcessStep;
using PaymentProcessor.Transaction.Model;

namespace PaymentProcessor.Processor
{
    public class ProcessRunner<TContext> : IProcessRunner, IProcessRunner<TContext>
        where TContext : IProcessContext
    {
        
        private readonly ProcessStepFactory processStepFactory;

        public ProcessRunner(ProcessStepFactory processStepFactory, TContext processContext)
        {
            
            this.processStepFactory = processStepFactory;
            ProcessContext = processContext;
        }

        public TContext ProcessContext { get; init; }

        IProcessContext IProcessRunner.ProcessContext
        { 
            get => ProcessContext; 
            init => ProcessContext = (TContext)value; 
        }

        public bool Run(ITransactionModel transaction)
        {
            ProcessContext.Transaction = transaction;
            Steps();
            return ProcessContext.ProcessState;
        }

        public async Task<bool> RunAsync(ITransactionModel transaction)
        {
            ProcessContext.Transaction = transaction;
            await StepsAsync();
            return ProcessContext.ProcessState;
        }

        protected virtual void Steps()
        {
        }

        protected virtual async Task StepsAsync()
        {
        }

        protected void HandleException(Exception exception)
        {
            ProcessContext.ProcessState = false;
            // TODO: sanitize and log exception
        }

        protected void RunStep<T>() where T : IProcessStep
        {
            try
            {
                var step = processStepFactory(typeof(T));
                ProcessContext.ProcessState = step.Run();
            }
            catch(Exception e)
            {
                HandleException(e);
            }
        }

        protected async Task RunStepAsync<T>() where T : IProcessStep
        {
            try
            {
                var step = processStepFactory(typeof(T));
                var result = await step.RunAsync();
                ProcessContext.ProcessState = result;
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }
    }
}
