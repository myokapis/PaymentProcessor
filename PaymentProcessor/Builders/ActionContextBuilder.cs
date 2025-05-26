using PaymentProcessor.Transaction.Context;
using PaymentProcessor.Transaction.Model;

namespace PaymentProcessor.Builders
{
    public class ActionContextBuilder : IBuilder<ActionContext>
    {
        public ActionContext Build(ITransactionModel transaction)
        {
            var action = transaction.Details.Action.ToUpper();

            return new ActionContext()
            {
                // TODO: map the remaining attributes
                Auth = (action == "AUTH"),
                Return = (action == "RETURN"),
                Sale = (action == "SALE"),
                TransactionType = action
            };
        }
    }
}
