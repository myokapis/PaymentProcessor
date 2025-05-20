using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
{
    public class PartialAuthIndicatorMapper : Mapper<PartialAuthIndicator>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new PartialAuthIndicator();
        }
    }
}
