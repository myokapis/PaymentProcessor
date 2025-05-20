using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;
using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class CardProductCodeMapper : Mapper<CardProductCode>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new CardProductCode();
        }
    }
}
