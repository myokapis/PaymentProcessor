using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
{
    public class MasterCardPaymentIndicatorsMapper : Mapper<MastercardPaymentIndicators>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new MastercardPaymentIndicators()
            {
                DeviceType = "DVT001"
            };
        }
    }
}
