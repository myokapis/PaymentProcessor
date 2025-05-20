namespace PaymentProcessor.Requests.Messages.ValueGroups
{
    public class MotoEcommIndicator : AccessibleMessage<MotoEcommIndicator>
    {
        public string GroupName { get; } = "014";
        public int Indicator { get; set; }
    }
}
