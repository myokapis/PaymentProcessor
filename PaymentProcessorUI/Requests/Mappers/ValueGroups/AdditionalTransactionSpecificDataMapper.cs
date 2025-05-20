using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
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
