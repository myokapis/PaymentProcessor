using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class CommercialCardRequestIndicatorMapper : Mapper<CommercialCardRequestIndicator>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new CommercialCardRequestIndicator();
        }
    }
}
