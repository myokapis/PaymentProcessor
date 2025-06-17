using Payment.Messages.Enums;

namespace Payment.Messages.Attributes.Format
{
    public class DateFormatAttribute : FormatAttribute
    {
        public DateFormatAttribute() : base()
        { }

        public override string FormatString { get; init; } = "r";
        public override Justify Justify { get; init; } = Justify.None;
        public override char PaddingChar { get; init; } = ' ';
    }
}
