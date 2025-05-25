using PaymentProcessor.Processor.Context;

namespace PaymentProcessor.Builders
{
    public class Builder<TContext, T> : IBuilder<T>
    {
        private TContext processContext;

        public Builder(TContext processContext)
        {
            this.processContext = processContext;
        }

        public virtual T Build() => throw new NotImplementedException();
    }
}
