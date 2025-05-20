using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class AdditionalTransactionSpecificDataMapper : Mapper<AdditionalTransactionSpecificData>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new AdditionalTransactionSpecificData()
            {
                MerchantPaymentGatewayId = "MPGID",
                TransactionLinkIdentifier = "TLID"
            };
        }
    }
}
