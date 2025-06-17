using PaymentProcessor.Messages;
using PaymentProcessor.Transaction.Context;

namespace Payment.Mappers
{
    public abstract class Mapper<TContext, TMessage> : IMapper, IMapper<TContext>
        where TContext : ITransactionContext
        where TMessage : IAccessibleMessage
    {
        public Mapper()
        { }

        public virtual IAccessibleMessage Map(TContext transaction)
        {
            throw new NotImplementedException();
        }

        IAccessibleMessage IMapper.Map(ITransactionContext transactionContext)
        {
            return Map((TContext)transactionContext);
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
