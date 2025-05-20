using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;

namespace TsysProcessor.Requests.Mappers.ValueGroups
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
