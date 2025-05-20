using System.Runtime.CompilerServices;
using PaymentProcessor.Enums;

namespace PaymentProcessor.Format.Attributes
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
