namespace PaymentProcessor.Requests.Messages.ValueGroups
{
    public class CitMitIndicator : AccessibleMessage<CitMitIndicator>
    {
        public string GroupName { get; } = "083";
        public required string Indicator { get; set; }
    }
}
