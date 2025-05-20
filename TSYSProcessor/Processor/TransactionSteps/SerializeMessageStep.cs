using System.Text;
using PaymentProcessor.Serializers;
using PaymentProcessor.Processor.Context;
using PaymentProcessor.Processor.ProcessStep;

namespace TsysProcessor.Processor.Transaction
{
    public class SerializeMessageStep : IProcessStep
    {
        private readonly IMessageSerializer serializer;

        public SerializeMessageStep(IProcessContext processContext, IMessageSerializer serializer)
        {
            ProcessContext = processContext;
            this.serializer = serializer;
        }

        public IProcessContext ProcessContext { get; init; }
        public bool Run()
        {
            if (ProcessContext.RequestMessage == null) throw new ArgumentNullException("RequestMessage is required.");
            var builder = new StringBuilder();
            serializer.SerializeMessage(ProcessContext.RequestMessage, builder);
            ProcessContext.SerializedRequest = builder.ToString();
            return true;
        }
    }
}
