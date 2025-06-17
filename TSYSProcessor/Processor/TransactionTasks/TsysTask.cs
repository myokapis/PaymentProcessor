using Payment.Workflow;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class TsysTask : WorkflowTask
    {
        public TsysTask(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
            WorkflowContext = workflowContext;
        }

        protected new TsysWorkflowContext WorkflowContext { get; init; }
    }
}
