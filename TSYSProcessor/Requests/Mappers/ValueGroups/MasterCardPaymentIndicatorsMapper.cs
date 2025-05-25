using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;
using PaymentProcessor.Transaction.Model;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class MasterCardPaymentIndicatorsMapper : Mapper<TsysTransactionContext, MastercardPaymentIndicators>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new MastercardPaymentIndicators()
            {
                DeviceType = "DVT001"
            };
        }
    }
}
