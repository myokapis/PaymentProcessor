using System.Text;
using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Serializers;
using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers
{
    public abstract class Mapper<TMessage> : IMapper where TMessage : IAccessibleMessage // , new()
    {
        public Mapper()
        { }

        public virtual IAccessibleMessage Map(Body transaction)
        {
            throw new NotImplementedException();
        }

        // TODO: decide if we need this. If not, then kill this abstract class
        public virtual IAccessibleMessage SetFields(IAccessibleMessage message, Dictionary<string, object> fieldValues)
        {
            foreach (var fieldDefinition in message.FieldDefinitions)
            {
                var property = fieldDefinition.PropertyInfo;
                var value = fieldValues[property.Name];
                property.SetValue(message, value);
            }

            return message;
        }

        //protected virtual IAccessibleMessage SetFieldValues(Body transaction)
        //{
        //    return new TMessage();
        //}

        //protected virtual IAccessibleMessage SetFieldValues(Body transaction, Dictionary<string, object> fieldValues)
        //{
        //    var message = new TMessage();

        //    foreach (var fieldDefinition in message.FieldDefinitions)
        //    {
        //        var property = fieldDefinition.PropertyInfo;
        //        var value = fieldValues[property.Name];
        //        property.SetValue(message, value);
        //    }

        //    return message;
        //}
    }
}
