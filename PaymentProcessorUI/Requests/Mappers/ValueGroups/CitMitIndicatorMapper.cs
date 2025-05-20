using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
{
    public class CitMitIndicatorMapper : Mapper<CitMitIndicator>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new CitMitIndicator()
            {
                Indicator = "M101"
            };
        }
    }
}
