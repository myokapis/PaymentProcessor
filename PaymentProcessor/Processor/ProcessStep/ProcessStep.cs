using PaymentProcessor.Processor.Context;

namespace PaymentProcessor.Processor.ProcessStep
{
    public class ProcessStep<TContext> : IProcessStep, IProcessStep<TContext>
        where TContext : IProcessContext
    {

        public ProcessStep(TContext processContext)
        {
            ProcessContext = processContext;
        }

        public TContext ProcessContext { get; init; }

        IProcessContext IProcessStep.ProcessContext
        {
            get => ProcessContext;
            init => ProcessContext = (TContext)value;
        }

        public bool Run()
        {
            if (ProcessContext.ProcessState)
            {
                return RunActive();
            }
            else return RunErrored();
        }

        public async Task<bool> RunAsync()
        {
            if (ProcessContext.ProcessState)
            {
                return await RunActiveAsync();
            }
            else return await RunErroredAsync();
        }

        protected virtual bool RunActive()
        {
            return true;
        }

        protected virtual async Task<bool> RunActiveAsync()
        {
            return await Task.FromResult(true);
        }

        protected virtual bool RunErrored()
        {
            return false;
        }

        protected virtual async Task<bool> RunErroredAsync()
        {
            return await Task.FromResult(false);
        }
    }
}
