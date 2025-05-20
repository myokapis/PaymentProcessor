using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class FraudEnhancedDataMapper : Mapper<FraudEnhancedData>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new FraudEnhancedData();
        }
    }
}
