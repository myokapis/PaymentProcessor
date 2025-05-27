using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Processor.Context;
using PaymentProcessor.Processor.ProcessStep;
using TsysProcessor.Processor.Context;

namespace TsysProcessor.Processor.TransactionSteps
{
    public class SendMessage : ProcessStep<TsysProcessContext>
    {
        public SendMessage(TsysProcessContext processContext) : base(processContext)
        { }

        protected override async Task<bool> RunActiveAsync()
        {
            var requestMessage = ProcessContext.RequestMessage;
            if (requestMessage == null) throw new ArgumentNullException("Request message is required.");

            // TODO: send request and set raw response
            ProcessContext.ProcessorResponse = "";
            return true;
        }
    }
}
