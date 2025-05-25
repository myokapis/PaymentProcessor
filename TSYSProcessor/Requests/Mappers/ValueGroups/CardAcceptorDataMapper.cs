using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;
using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction.Model;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class CardAcceptorDataMapper : Mapper<TsysTransactionContext, CardAcceptorData>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new CardAcceptorData()
            {
                // TODO: map fields
            };
        }
    }
}
