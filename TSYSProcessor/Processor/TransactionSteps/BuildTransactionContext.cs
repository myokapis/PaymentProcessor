using PaymentProcessor.Builders;
using PaymentProcessor.Processor.ProcessStep;
using PaymentProcessor.Transaction.Context;
using TsysProcessor.Processor.Context;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;

namespace TsysProcessor.Processor.TransactionSteps
{
    class BuildTransactionContext : ProcessStep<TsysProcessContext>
    {
        private readonly IBuilder<ActionContext> actionContextBuilder;

        public BuildTransactionContext(TsysProcessContext processContext, IBuilder<ActionContext> actionContextBuilder) : base(processContext)
        {
            this.actionContextBuilder = actionContextBuilder;
        }

        protected override bool RunActive()
        {
            if (ProcessContext?.Transaction is not TsysTransaction transaction) throw new ArgumentNullException("Transaction");

            var transactionContext = new TsysTransactionContext()
            {
                // TODO: finish defining the context and setting properties
                ActionContext = actionContextBuilder.Build(transaction),
                // TODO: call the card decryption utility
                Card = BuildCard(transaction.Details.EncryptedCardData),
                Details = transaction.Details,
                // TODO: call an envelope builder or utility
                Envelope = BuildEnvelope(),
                Merchant = transaction.Merchant,
                ProcessorAttributes = transaction.ProcessorAttributes,
                // TODO: should this be a reader context with booleans and other helper methods?
                Reader = transaction.Details.Reader
            };

            ProcessContext.TransactionContext = transactionContext;

            return true;
        }

        // TODO: inject the builders and utilities instead of newing these up
        protected Card BuildCard(string EncryptedCardData)
        {
            return new Card()
            { 
                DataSource = "",
                TransactionMethod = ""
            };
        }

        protected TsysEnvelope BuildEnvelope()
        {
            return new TsysEnvelope();
        }
    }
}
