using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using PaymentProcessor.Format.Attributes;
using PaymentProcessor.Format.Serialization;

namespace PaymentProcessor.Messages
{
    public class AccessibleMessage<T> : IAccessibleMessage
    {
        public AccessibleMessage()
        { }

        //public AccessibleMessage(Dictionary<string, object> fieldValues)
        //{
        //    foreach (var fieldDefinition in fieldDefinitions.Value)
        //    {
        //        var property = fieldDefinition.PropertyInfo;
        //        var value = fieldValues[property.Name];
        //        property.SetValue(this, value);
        //    }
        //}

        #region Static Variables

        private static Lazy<FieldDefinition[]> fieldDefinitions =
            new Lazy<FieldDefinition[]>(
                    GetFieldCollection,
                    LazyThreadSafetyMode.ExecutionAndPublication
                );

        #endregion

        #region Public Methods and Properties

        /// <summary>
        /// Count of accessible property fields on the data object
        /// </summary>
        [NotMapped]
        public int FieldCount => fieldDefinitions.Value.Length;

        [NotMapped]
        public IEnumerable<FieldDefinition> FieldDefinitions
        {
            get
            {
                foreach(var field in fieldDefinitions.Value)
                {
                    yield return field;
                }
            }
        }

        #endregion

        #region "protected methods"

        protected static FieldDefinition[] GetFieldCollection()
        {
            return GetFieldProperties()
                .Select(pi => new FieldDefinition()
                {
                    FormatAttribute = pi.GetCustomAttribute<FormatAttribute>(),
                    PropertyInfo = pi,
                    SerializationAttribute = pi.GetCustomAttribute<SerializationAttribute>()
                })
                .ToArray();
        }

        /// <summary>
        /// A static method that finds public properties of the class. Any properties marked with
        /// the [NotMapped] attribute are ignored.
        /// </summary>
        protected static PropertyInfo[] GetFieldProperties()
        {
            return typeof(T).GetProperties()
                .Where(pi => !Attribute.IsDefined(pi, typeof(NotMappedAttribute)))
                .ToArray();
        }

        #endregion
    }
}
