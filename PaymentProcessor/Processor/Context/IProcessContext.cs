using PaymentProcessor.Messages;
using PaymentProcessor.Transaction.Model;
using PaymentProcessor.Transaction.Context;

namespace PaymentProcessor.Processor.Context
{
    public interface IProcessContext<TModel, TContext> : IProcessContext
        where TModel : ITransactionModel
        where TContext : ITransactionContext
    {
        new TModel? Transaction { get; set; }
        new TContext? TransactionContext { get; set; }
    }

    public interface IProcessContext
    {
        string? ProcessorResponse { get; set; }
        IAccessibleMessage? RequestMessage { get; set; }
        string? SerializedRequest { get; set; }
        bool ProcessState { get; set; }
        ITransactionModel? Transaction { get; set; }
        ITransactionContext? TransactionContext { get; set; }
    }
}
