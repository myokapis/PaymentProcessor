﻿namespace Payment.Messages.Mappers
{
    public abstract class Mapper<TContext, TMessage> : IMapper<TContext>
        where TMessage : IAccessibleMessage
    {
        public Mapper()
        { }

        public virtual IAccessibleMessage Map(TContext transaction)
        {
            throw new NotImplementedException();
        }

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
    }
}
