namespace PaymentProcessor.Requests.Messages.ValueGroups
{
    public class TransactionIntegrityClass : AccessibleMessage<TransactionIntegrityClass>
    {
        public string GroupName { get; } = "074";
    }
}
