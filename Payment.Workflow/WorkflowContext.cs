using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    public class WorkflowContext : IWorkflowContext

    {
        public WorkflowContext()
        { }

        public bool WorkflowState { get; set; } = true;
    }
}
