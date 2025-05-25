using PaymentProcessor.Messages;
using PaymentProcessor.Transaction.Context;
using PaymentProcessor.Transaction.Model;

namespace PaymentProcessor.Processor.Context
{
    public class ProcessContext<TModel, TContext> : IProcessContext<TModel, TContext>
        where TModel : ITransactionModel
        where TContext : ITransactionContext
    {
        public ProcessContext()
        { }

        public string? ProcessorResponse { get; set; }
        public bool ProcessState { get; set; } = true;
        public IAccessibleMessage? RequestMessage { get; set; }
        public string? SerializedRequest { get; set; }
        public TModel? Transaction { get; set; }
        public TContext? TransactionContext { get; set; }
        ITransactionModel? IProcessContext.Transaction { get => Transaction; set => Transaction = (TModel?)value; }
        ITransactionContext? IProcessContext.TransactionContext { get => TransactionContext; set => TransactionContext = (TContext?)value; }
    }
}
