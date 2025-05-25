using PaymentProcessor.Processor.Context;
using PaymentProcessor.Transaction.Context;

namespace PaymentProcessor.Builders
{
    // TODO: decide if we need this builder. The decryption utility could always return a Card object instead.
    public class CardBuilder<TContext> : Builder<TContext, Card>
    {
        public CardBuilder(TContext processContext) : base(processContext)
        {

        }
    }
}
