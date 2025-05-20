using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;
using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;

namespace TsysProcessor.Requests.Mappers.ValueGroups
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
