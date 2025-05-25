using System.Text;
using PaymentProcessor.Format.Attributes;
using PaymentProcessor.Format.Serialization;
using PaymentProcessor.Messages;

namespace PaymentProcessor.Serializers
{
    public class StringSerializer : IMessageSerializer
    {
        public StringSerializer()
        {
        }

        public void SerializeMessage(IAccessibleMessage? message, StringBuilder builder, bool isMasked = false)
        {
            if (message == null) return;

            foreach (var fieldDefinition in message.FieldDefinitions)
            {
                FieldContent fieldContent = ExtractContent(message, fieldDefinition);
                int messageLength = builder.Length;

                if (fieldContent.Value is IAccessibleMessage)
                {
                    SerializeMessage((IAccessibleMessage)fieldContent.Value, builder);
                }
                else
                {
                    var fieldValue = FormatField(fieldContent, isMasked);
                    builder.Append(fieldValue);
                }

                var terminator = fieldDefinition.SerializationAttribute?.Terminator;
                var terminate = (fieldDefinition.SerializationAttribute?.AlwaysTerminate ?? false) || 
                    (builder.Length > messageLength);

                if ((terminator != null) && terminate) builder.Append(terminator);
            }
        }

        /// <summary>
        /// Returns a FieldValue object for a given field in the field collection.
        /// </summary>
        /// <param name="field">The </param>
        /// <returns>A FieldValue object containing the field's data and relevant metadata.</returns>
        protected FieldContent ExtractContent(IAccessibleMessage message, FieldDefinition field)
        {
            return new FieldContent()
            {
                FieldName = field.PropertyInfo.Name,
                FormatAttribute = field.FormatAttribute,
                SerializationAttribute = field.SerializationAttribute,
                Value = field.PropertyInfo.GetValue(message)
            };
        }


        // TODO: move the formatters into another class
        protected string FormattedFieldValue(FieldContent fieldContent)
        {
            var value = fieldContent.Value;
            if (value == null) return "";

            if (fieldContent.FormatAttribute == null) return value.ToString() ?? "";

            return FormatValue(value, fieldContent.FormatAttribute!);
        }

        protected string FormatField(FieldContent fieldContent, bool isMasked)
        {
            var formattedValue = FormattedFieldValue(fieldContent);
            var workingValue = isMasked ? MaskValue(formattedValue, fieldContent) : formattedValue;
            return JustifyValue(workingValue, fieldContent);
        }

        protected string FormatValue(DateTime value, FormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        protected string FormatValue(decimal value, FormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        protected string FormatValue(int value, FormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        protected string FormatValue(object value, FormatAttribute _formatter)
        {
            return value.ToString() ?? "";
        }

        protected string FormatValue(string value, FormatAttribute formatter)
        {
            return string.Format(formatter.FormatString, value);
        }

        protected string FormatValue(uint value, FormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        protected string FormatValue(ulong value, FormatAttribute formatter)
        {
            return value.ToString(formatter.FormatString);
        }

        protected string MaskValue(string value, FieldContent fieldContent)
        {
            var formatter = fieldContent.SerializationAttribute;
            if (formatter == null) return value;

            return new string(formatter.MaskChar, value.Length);
        }

        protected string JustifyValue(string value, FieldContent fieldContent)
        {
            var formatter = fieldContent.FormatAttribute;
            if (formatter == null) return value;

            if ((formatter.Justify == Enums.Justify.None) || (formatter.PaddedLength == 0))
            {
                if ((formatter.MaxLength == 0) ||(value.Length <= formatter.MaxLength)) return value;
                value.Substring(formatter.MaxLength);
            }

            if (formatter.Justify == Enums.Justify.Left)
                return value.PadLeft(formatter.PaddedLength, formatter.PaddingChar);

            return value.PadRight(formatter.PaddedLength, formatter.PaddingChar);
        }
    }
}
