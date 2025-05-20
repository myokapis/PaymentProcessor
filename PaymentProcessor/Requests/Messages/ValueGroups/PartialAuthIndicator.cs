namespace PaymentProcessor.Requests.Messages.ValueGroups
{
    public class PartialAuthIndicator : AccessibleMessage<PartialAuthIndicator>
    {
        public string GroupName { get; } = "026";
        public char Indicator { get; set; }
    }
}
