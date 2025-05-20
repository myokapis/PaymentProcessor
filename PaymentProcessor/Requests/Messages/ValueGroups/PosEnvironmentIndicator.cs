namespace PaymentProcessor.Requests.Messages.ValueGroups
{
    public class PosEnvironmentIndicator : AccessibleMessage<PosEnvironmentIndicator>
    {
        public string GroupName { get; } = "071";
        public char EnvironmentIndicator { get; set; }
    }
}
