using System.Text;
using Payment.Messages.Serializers;
using TsysProcessor.Processor.TransactionTasks;
using TsysProcessor.Workflow.Context;
namespace TsysProcessor.Processor.Transaction
{
    public class SerializeMessage : TsysTask
    {
        private readonly IMessageSerializer serializer;

        public SerializeMessage(TsysWorkflowContext processContext, IMessageSerializer serializer) : base(processContext)
        {
            this.serializer = serializer;
        }

        protected override bool RunActive()
        {
            if (WorkflowContext.RequestMessage == null) throw new ArgumentNullException("RequestMessage is required.");
            var builder = new StringBuilder();
            serializer.SerializeMessage(WorkflowContext.RequestMessage, builder);
            WorkflowContext.SerializedRequest = builder.ToString();
            return true;
        }
    }
}
