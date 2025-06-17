using Payment.Workflow;
using Payment.Workflow.Factories.Delegates;
using TsysProcessor.Processor.Transaction;
using TsysProcessor.Processor.TransactionSteps;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor
{
    public class TsysTransactionRunner : WorkflowRunner
    {
        public TsysTransactionRunner(WorkflowTaskFactory workflowTaskFactory, TsysWorkflowContext workflowContext) :
            base(workflowTaskFactory, workflowContext)
        {
            WorkflowContext = workflowContext;
        }

        public new TsysWorkflowContext WorkflowContext { get; init; }

        public async Task<bool> RunAsync(TsysTransaction tsysTransaction)
        {
            WorkflowContext.Transaction = tsysTransaction;
            return await RunAsync();
        }

        public async Task<bool> RunAsync(TsysTransactionContext tsysTransactionContext)
        {
            WorkflowContext.TransactionContext = tsysTransactionContext;
            return await RunAsync();
        }

        protected override async Task WorkflowTasksAsync()
        {
            // TODO: add steps here
            RunWorkflowTask<BuildTransactionContext>();
            RunWorkflowTask<BuildMessage>();
            RunWorkflowTask<SerializeMessage>();
            await RunWorkflowTaskAsync<SendMessage>();
        }
    }
}
