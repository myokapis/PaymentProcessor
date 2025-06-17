using System.Text;

namespace Payment.Mappers
{
    public class ParentMapper<TContext, TMessage> : Mapper<TContext, TMessage>
        where TContext : ITransactionContext
        where TMessage : IAccessibleMessage
    {
        protected MapperFactory mapperFactory;
        protected IMessageSerializer messageSerializer;

        public ParentMapper(MapperFactory mapperFactory, IMessageSerializer messageSerializer) : base()
        {
            this.mapperFactory = mapperFactory;
            this.messageSerializer = messageSerializer;
        }

        protected virtual IAccessibleMessage MapGroup<TChildMapper>(TContext transactionContext) where TChildMapper : IMapper<TContext>
        {
            var mapper = mapperFactory(typeof(TChildMapper));
            return mapper.Map(transactionContext);
        }

        protected string MapValueGroup<TChildMapper>(TContext transactionContext, StringBuilder builder) where TChildMapper : IMapper<TContext>
        {
            var message = MapGroup<TChildMapper>(transactionContext);
            builder.Clear();
            messageSerializer.SerializeMessage(message, builder);
            return builder.ToString();
        }
    }
}
