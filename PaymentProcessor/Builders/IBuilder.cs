using PaymentProcessor.Transaction;

namespace PaymentProcessor.Builders
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
