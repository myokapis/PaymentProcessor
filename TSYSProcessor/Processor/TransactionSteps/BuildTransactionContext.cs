using PaymentProcessor.Processor.Context;
using PaymentProcessor.Processor.ProcessStep;
using PaymentProcessor.Transaction.Context;
using TsysProcessor.Processor.Context;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;

namespace TsysProcessor.Processor.TransactionSteps
{
    class BuildTransactionContext : ProcessStep<TsysProcessContext>
    {
        public BuildTransactionContext(TsysProcessContext processContext) : base(processContext)
        {
        }

        protected override bool RunActive()
        {
            if (ProcessContext?.Transaction is not TsysTransaction transaction) throw new ArgumentNullException("Transaction");

            var transactionContext = new TsysTransactionContext()
            {
                // TODO: finish defining the context and setting properties
                ActionContext = BuildActionContext(),
                Card = BuildCard(transaction.Details.EncryptedCardData),
                Details = transaction.Details,
                Envelope = BuildEnvelope(),
                Merchant = transaction.Merchant,
                ProcessorAttributes = transaction.ProcessorAttributes,
                // TODO: should this be a reader context with booleans and other helper methods?
                Reader = transaction.Details.Reader
            };

            ProcessContext.TransactionContext = transactionContext;

            return true;
        }

        protected ActionContext BuildActionContext()
        {
            return new ActionContext()
            { 
                TransactionType = ""
            };
        }

        protected Card BuildCard(string EncryptedCardData)
        {
            return new Card()
            { 
                DataSource = "",
                TransactionMethod = ""
            };
        }

        protected Envelope BuildEnvelope()
        {
            return new Envelope();
        }
    }
}
