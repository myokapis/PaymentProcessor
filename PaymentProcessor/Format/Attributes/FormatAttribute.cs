using PaymentProcessor.Enums;

namespace PaymentProcessor.Format.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public abstract class FormatAttribute : Attribute, IFormatAttribute
    {
        public FormatAttribute() {}

        public virtual string FormatString { get; init; } = string.Empty;
        public virtual Justify Justify { get; init; } = Justify.Left;
        public virtual int MaxLength { get; set; } = 0;
        public virtual int PaddedLength { get; set; } = 0;
        public virtual char PaddingChar { get; init; } = ' ';
    }
}
