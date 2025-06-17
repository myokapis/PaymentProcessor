using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Transaction.Context
{
    public class TransactionContext<TEnvelope, TAttributes> : ITransactionContext, ITransactionContext<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope<TEnvelope>
        where TAttributes : IProcessorAttributes
    {
        public required Card Card { get; set; }
        public required Details Details { get; set; }
        public TEnvelope? Envelope { get; set; }
        public required Merchant Merchant { get; set; }
        public required TAttributes ProcessorAttributes { get; set; }
        public required Reader Reader { get; set; }
        public required ActionContext ActionContext { get; set; }
        IEnvelope? ITransactionContext.Envelope { get => Envelope; set => Envelope = (TEnvelope?)value; }

        IEnvelope<TEnvelope>? ITransactionContext<TEnvelope, TAttributes>.Envelope
        { 
            get => Envelope; 
            set => Envelope = (TEnvelope?)value; 
        }

        IProcessorAttributes ITransactionContext.ProcessorAttributes
        {
            get => ProcessorAttributes;
            set => ProcessorAttributes = (TAttributes)value;
        }
    }
}
