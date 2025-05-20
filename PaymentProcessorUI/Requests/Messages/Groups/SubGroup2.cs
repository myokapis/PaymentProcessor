using PaymentProcessor.Requests.Messages;

namespace PaymentProcessor.Requests.Messages.Groups
{
    public class SubGroup2 : AccessibleMessage<SubGroup2>
    {
        public string Name { get; set; } = "SubGroup2";
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
