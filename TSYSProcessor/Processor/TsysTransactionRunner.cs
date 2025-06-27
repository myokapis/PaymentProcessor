using Payment.Workflow;
using Payment.Workflow.Factories.Delegates;
using TsysProcessor.Processor.Transaction;
using TsysProcessor.Processor.TransactionSteps;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor
{
    public class TsysTransactionRunner : WorkflowRunner<TsysWorkflowContext>
    {
        public TsysTransactionRunner(WorkflowTaskFactory workflowTaskFactory, TsysWorkflowContext workflowContext) :
            base(workflowTaskFactory, workflowContext)
        {
        }

        protected override void HandleException(Exception exception)
        {
            // TODO: log error here
            //       do we need an async version or do most loggers buffer and handle
            //       writes on a background task?
        }

        protected override async Task RunWorkflowTasks()
        {
            // TODO: add steps here
            RunWorkflowTask<BuildTransactionContext>();
            RunWorkflowTask<BuildMessage>();
            RunWorkflowTask<SerializeMessage>();
            await RunWorkflowTaskAsync<SendMessage>();
        }
    }
}
