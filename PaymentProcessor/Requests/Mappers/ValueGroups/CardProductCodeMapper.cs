using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
{
    public class CardProductCodeMapper : Mapper<CardProductCode>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new CardProductCode();
        }
    }
}
