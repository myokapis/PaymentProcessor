using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Transaction.Context
{
    public interface ITransactionContext<TEnvelope, TAttributes> : ITransactionContext
        where TEnvelope : IEnvelope<TEnvelope>
        where TAttributes : IProcessorAttributes
    {
        new IEnvelope<TEnvelope>? Envelope { get; set; }
        new TAttributes ProcessorAttributes { get; set; }
    }

    public interface ITransactionContext
    {
        Card Card { get; set; }
        Details Details { get; set; }
        IEnvelope? Envelope { get; set; }
        Merchant Merchant { get; set; }
        IProcessorAttributes ProcessorAttributes { get; set; }
        Reader Reader { get; set; }
        ActionContext ActionContext { get; set; }
    }
}
