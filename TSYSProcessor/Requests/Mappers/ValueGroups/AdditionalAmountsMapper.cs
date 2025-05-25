using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;
using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction.Model;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class AdditionalAmountsMapper : Mapper<TsysTransactionContext, AdditionalAmounts>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new AdditionalAmounts();
        }
    }
}
