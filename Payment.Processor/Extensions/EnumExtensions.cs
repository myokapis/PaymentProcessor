using Payment.Processor.Enums;

namespace Payment.Processor.Extensions
{
    public static class EnumExtensions
    {
        public static bool OneOf<TEnum>(this TEnum value, params TEnum[] valueSet) where TEnum : struct
        {
            return valueSet.Any(m => m.Equals(value));
        }

        /// <summary>
        /// Parses a string to an enumerated value of the calling type.
        /// Defaults to the calling value when parsing fails.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="defaultValue">Value that is calling the extension method</param>
        /// <param name="value">String value to be parsed.</param>
        /// <returns>An enumerated value of the calling type</returns>
        public static TEnum Parse<TEnum>(this TEnum defaultValue, string? value) where TEnum : struct
        {
            if (!Enum.TryParse<TEnum>(value, true, out var result))
                result = defaultValue;

            return result;
        }
    }
}
