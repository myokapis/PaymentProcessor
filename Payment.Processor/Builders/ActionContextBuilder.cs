using Payment.Processor.Enums;
using Payment.Processor.Extensions;
using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    public class ActionContextBuilder : IBuilder<ActionContext>
    {
        public ActionContext Build(ITransactionModel transaction)
        {
            var action = transaction.Details.Action;
            var actionType = ActionType.None.Parse(action);
            var cardAuth = CardAuthentication(actionType, transaction.Details);

            return new ActionContext()
            {
                ActionType = actionType,
                AuthAction = (cardAuth || (actionType == ActionType.PreAuth)),
                AutoVoid = (actionType == ActionType.AutoVoid),
                Capture = (actionType == ActionType.Capture),
                CardAuth = cardAuth,
                PreAuth = (actionType == ActionType.PreAuth),
                PrimaryAction = cardAuth || actionType.OneOf(ActionType.PreAuth, ActionType.Sale),
                Return = (actionType == ActionType.Return),
                Sale = (actionType == ActionType.Sale),
                TimeoutReversal = (actionType == ActionType.TimeoutReversal),

                // TODO: rename this to indicate that these are transactions that move money
                Transaction = actionType.OneOf(ActionType.Return, ActionType.Sale),

                Void = (actionType == ActionType.Void),
                VoidAction = actionType.OneOf(ActionType.AutoVoid, ActionType.TimeoutReversal, ActionType.Void),
            };
        }

        protected bool CardAuthentication(ActionType actionType, Details transactionDetails)
        {
            if (actionType == ActionType.CardAuth) return true;

            var metadata = transactionDetails.Metadata;
            if (metadata == null) return false;

            return metadata.CardAuthentication && (actionType == ActionType.PreAuth);
        }

        //protected bool OneOf(ActionType actionType, params ActionType[] matchSet)
        //{
        //    return matchSet.Any(m => m == actionType);
        //}
    }
}
