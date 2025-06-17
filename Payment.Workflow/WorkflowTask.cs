using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    public class WorkflowTask : IWorkflowTask
    {

        public WorkflowTask(IWorkflowContext workflowContext)
        {
            WorkflowContext = workflowContext;
        }

        public IWorkflowContext WorkflowContext { get; init; }

        public bool Run()
        {
            if (WorkflowContext.WorkflowState)
            {
                return RunActive();
            }
            else return RunErrored();
        }

        public async Task<bool> RunAsync()
        {
            if (WorkflowContext.WorkflowState)
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
