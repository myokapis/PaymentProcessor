using Payment.Workflow.Factories.Delegates;
using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    // TODO: make this abstract and implement a payment processor specific version in that project
    public class WorkflowRunner : IWorkflowRunner
    {
        
        private readonly WorkflowTaskFactory workflowTaskFactory;

        public WorkflowRunner(WorkflowTaskFactory workflowTaskFactory, IWorkflowContext workflowContext)
        {
            
            this.workflowTaskFactory = workflowTaskFactory;
            WorkflowContext = workflowContext;
        }

        public IWorkflowContext WorkflowContext { get; init; }

        public virtual bool Run()
        {
            WorkflowTasks();
            return WorkflowContext.WorkflowState;
        }

        public async virtual Task<bool> RunAsync()
        {
            await WorkflowTasksAsync();
            return WorkflowContext.WorkflowState;
        }

        protected virtual void WorkflowTasks()
        {
        }

        protected virtual async Task WorkflowTasksAsync()
        {
        }

        protected void HandleException(Exception exception)
        {
            WorkflowContext.WorkflowState = false;
        }

        protected void RunWorkflowTask<T>() where T : IWorkflowTask
        {
            try
            {
                var workflowTask = workflowTaskFactory(typeof(T));
                WorkflowContext.WorkflowState = workflowTask.Run();
            }
            catch(Exception e)
            {
                HandleException(e);
            }
        }

        protected async Task RunWorkflowTaskAsync<T>() where T : IWorkflowTask
        {
            try
            {
                var workflowTask = workflowTaskFactory(typeof(T));
                var result = await workflowTask.RunAsync();
                WorkflowContext.WorkflowState = result;
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }
    }
}
