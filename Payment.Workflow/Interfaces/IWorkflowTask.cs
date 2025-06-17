namespace Payment.Workflow.Interfaces
{
    public interface IWorkflowTask
    {
        IWorkflowContext WorkflowContext { get; init; }
        bool Run();
        Task<bool> RunAsync();
    }
}
