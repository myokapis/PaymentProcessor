using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Processor.Context;
using PaymentProcessor.Processor.ProcessStep;
using TsysProcessor.Processor.Context;
using TsysProcessor.Requests.Mappers;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;

namespace TsysProcessor.Processor.Transaction
{
    public class BuildMessage : ProcessStep<TsysProcessContext>
    {
        protected readonly MapperFactory mapperFactory;

        public BuildMessage(TsysProcessContext processContext, MapperFactory mapperFactory) : base(processContext)
        {
            this.mapperFactory = mapperFactory;
        }

        protected override bool RunActive()
        {
            var transactionContext = ProcessContext.TransactionContext;
            if (transactionContext == null) throw new ArgumentNullException("Transaction is required.");

            var mapperType = GetMapperType(transactionContext);
            var mapper = mapperFactory(mapperType);
            ProcessContext.RequestMessage = mapper.Map(transactionContext);
            return true;
        }

        private Type GetMapperType(TsysTransactionContext transactionContext)
        {
            // TODO: add logic to select the mapper type based on the transaction details
            return typeof(SaleMapper);
        }
    }
}
