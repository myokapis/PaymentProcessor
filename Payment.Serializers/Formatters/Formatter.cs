using PaymentProcessor.Format.Attributes;

namespace PaymentProcessor.Serializers.Formatters
{
    public class Formatter : IFormatter
    {
        public string FormatValue(DateTime value, IFormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        public string FormatValue(decimal value, IFormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        public string FormatValue(int value, IFormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        public string FormatValue(object value, IFormatAttribute _formatter)
        {
            return value.ToString() ?? "";
        }

        public string FormatValue(string value, IFormatAttribute formatter)
        {
            return string.Format(formatter.FormatString, value);
        }

        public string FormatValue(uint value, IFormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        public string FormatValue(ulong value, IFormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }
    }
}
