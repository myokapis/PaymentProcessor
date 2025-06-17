namespace Payment.Workflow.Interfaces
{
    public interface IWorkflowRunner
    {
        bool Run();
        Task<bool> RunAsync();
    }
}
