using System.Text;
using PaymentProcessor.Serializers;
using PaymentProcessor.Processor.ProcessStep;
using TsysProcessor.Processor.Context;

namespace TsysProcessor.Processor.Transaction
{
    public class SerializeMessage : ProcessStep<TsysProcessContext>
    {
        private readonly IMessageSerializer serializer;

        public SerializeMessage(TsysProcessContext processContext, IMessageSerializer serializer) : base(processContext)
        {
            this.serializer = serializer;
        }

        protected override bool RunActive()
        {
            if (ProcessContext.RequestMessage == null) throw new ArgumentNullException("RequestMessage is required.");
            var builder = new StringBuilder();
            serializer.SerializeMessage(ProcessContext.RequestMessage, builder);
            ProcessContext.SerializedRequest = builder.ToString();
            return true;
        }
    }
}
