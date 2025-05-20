using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Processor.Context;
using PaymentProcessor.Processor.ProcessStep;
using PaymentProcessor.Requests.Mappers;

namespace PaymentProcessor.Processor.Transaction
{
    public class BuildMessageStep : IProcessStep
    {
        private readonly MapperFactory mapperFactory;

        public BuildMessageStep(IProcessContext processContext, MapperFactory mapperFactory)
        {
            this.mapperFactory = mapperFactory;
            ProcessContext = processContext;
        }

        public IProcessContext ProcessContext { get; init; }
        public bool Run()
        {
            var transaction = ProcessContext.Transaction;
            if (transaction == null) throw new ArgumentNullException("Transaction is required.");

            // TOOD: determine the mapper type from the transaction data
            var mapperType = typeof(SaleMapper);
            var mapper = mapperFactory(mapperType);
            ProcessContext.RequestMessage = mapper.Map(transaction);
            return true;
        }
    }
}
