using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Messages;
using PaymentProcessor.Serializers;
using PaymentProcessor.Transaction;
using System.Text;

namespace PaymentProcessor.Mappers
{
    public class ParentMapper<TMessage> : Mapper<TMessage> where TMessage : IAccessibleMessage
    {
        protected MapperFactory mapperFactory;
        protected IMessageSerializer messageSerializer;

        public ParentMapper(MapperFactory mapperFactory, IMessageSerializer messageSerializer) : base()
        {
            this.mapperFactory = mapperFactory;
            this.messageSerializer = messageSerializer;
        }

        protected virtual IAccessibleMessage MapGroup<TChildMapper>(Body transaction) where TChildMapper : IMapper
        {
            var mapper = mapperFactory(typeof(TChildMapper));
            return mapper.Map(transaction);
        }

        protected string MapValueGroup<TChildMapper>(Body transaction, StringBuilder builder) where TChildMapper : IMapper
        {
            var message = MapGroup<TChildMapper>(transaction);
            builder.Clear();
            messageSerializer.SerializeMessage(message, builder);
            return builder.ToString();
        }
    }
}
