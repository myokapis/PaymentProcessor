namespace PaymentProcessor.Requests.Messages.ValueGroups
{
    public class SpendQualifiedIndicator : AccessibleMessage<SpendQualifiedIndicator>
    {
        public string GroupName { get; } = "061";
    }
}
