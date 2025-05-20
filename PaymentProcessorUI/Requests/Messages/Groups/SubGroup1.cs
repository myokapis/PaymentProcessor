using PaymentProcessor.Format.Attributes;

namespace PaymentProcessor.Requests.Messages.Groups
{
    public class SubGroup1 : AccessibleMessage<SubGroup1>
    {
        [StringFormat(PaddedLength = 15, PaddingChar = '-')]
        public string Name { get; set; } = "SubGroup1";
        public SubGroup2? SubGroup2 { get; set; }
        public int SomeValue { get; set; } = 99;
    }
}
