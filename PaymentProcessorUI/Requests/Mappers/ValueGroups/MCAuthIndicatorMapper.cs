using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
{
    public class MCAuthIndicatorMapper : Mapper<MCAuthIndicator>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new MCAuthIndicator();
        }
    }
}
