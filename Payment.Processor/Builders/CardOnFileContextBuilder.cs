using Payment.Processor.Enums;
using Payment.Processor.Extensions;
using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    public class CardOnFileContextBuilder : IBuilder<CardOnFileContext>
    {
        public CardOnFileContextBuilder() { }

        public CardOnFileContext Build<TContext>(ITransactionModel transaction, TContext context)
        {
            var actionContext = context as ActionContext;
            if (actionContext == null) throw new ArgumentNullException(nameof(actionContext));

            var metadata = transaction.Details.Metadata;
            var sequenceIndicator = SequenceIndicator(transaction);
            var platform = Platform.Unknown.Parse(metadata?.Platform);
            var paymentPlanType = PaymentPlanType.None.Parse(metadata?.PaymentPlan?.PaymentPlanType);

            return new CardOnFileContext()
            {
                CardOnFile = CardOnFile(transaction, actionContext),
                FirstPayment = (sequenceIndicator == 1),
                InstallmentPayment = paymentPlanType == PaymentPlanType.Installment,
                MerchantInitiated = platform == Platform.ScheduledPayment,
                MultipartPayment = paymentPlanType.OneOf(PaymentPlanType.Installment, PaymentPlanType.Recurring),
                OneTimePayment = paymentPlanType == PaymentPlanType.OneTime,
                PaymentPlanId = metadata?.PaymentPlan?.PaymentPlanId,
                PaymentPlanType = paymentPlanType,
                Platform = metadata?.Platform,
                RecurringPayment = paymentPlanType == PaymentPlanType.Recurring,
                SaveCard = SaveCard(transaction, actionContext),
                ScheduledPayment = platform == Platform.ScheduledPayment,
                SequenceIndicator = SequenceIndicator(transaction),
                TotalPaymentCount = TotalPaymentCount(transaction)
            };
        }

        protected bool CardOnFile(ITransactionModel transaction, ActionContext actionContext)
        {
            if (actionContext.Return) return false;
            if (SaveCard(transaction, actionContext)) return false;
            return string.IsNullOrWhiteSpace(transaction.Details.CardOnFile?.ToString());
        }

        //protected bool OneOf(PaymentPlanType scheduledPaymentType, params PaymentPlanType[] matchSet)
        //{
        //    return matchSet.Any(m => m == scheduledPaymentType);
        //}


        protected bool SaveCard(ITransactionModel transaction, ActionContext actionContext)
        {
            if (actionContext.CardAuth) return true;

            var metadata = transaction.Details.Metadata;
            var saveCard = metadata?.Customer?.SaveCard;

            return (saveCard != null);
        }

        protected int? SequenceIndicator(ITransactionModel transaction)
        {
            var metadata = transaction.Details.Metadata;
            var value = metadata?.PaymentPlan?.SequenceIndicator?.ToString();

            if (!int.TryParse(value, out var sequenceIndicator))
                return null;

            return sequenceIndicator > 0 ? sequenceIndicator : null;
        }

        protected int? TotalPaymentCount(ITransactionModel transaction)
        {
            var metadata = transaction.Details.Metadata;
            var value = metadata?.PaymentPlan?.TotalPaymentCount?.ToString();

            if (!int.TryParse(value, out var sequenceIndicator))
                return null;

            return sequenceIndicator > 0 ? sequenceIndicator : null;
        }
    }
}
