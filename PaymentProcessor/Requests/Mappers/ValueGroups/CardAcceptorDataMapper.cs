using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
{
    public class CardAcceptorDataMapper : Mapper<CardAcceptorData>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new CardAcceptorData()
            {
                // TODO: map fields
            };
        }
    }
}
