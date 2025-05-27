using PaymentProcessor.Enums;

namespace PaymentProcessor.Format.Attributes
{
    public interface IFormatAttribute
    {
        string FormatString { get; init; }
        Justify Justify { get; init; }
        int MaxLength { get; set; }
        int PaddedLength { get; set; }
        char PaddingChar { get; init; }
    }
}
