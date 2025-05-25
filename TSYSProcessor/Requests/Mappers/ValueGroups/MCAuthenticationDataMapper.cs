using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;
using PaymentProcessor.Transaction.Model;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class MCAuthenticationDataMapper : Mapper<TsysTransactionContext, MCAuthenticationData>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new MCAuthenticationData();
        }
    }
}
