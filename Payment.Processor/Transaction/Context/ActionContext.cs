namespace Payment.Processor.Transaction.Context
{
    public class ActionContext
    {
        public bool Auth { get; init; }
        public bool AutoVoid { get; init; }
        public bool Capture { get; init; }
        public bool CardAuth { get; init; }
        public bool PreAuth { get; init; }
        public bool Return { get; init; }
        public bool Sale { get; init; }
        public bool TimeoutReversal { get; init; }
        public bool Transaction { get; init; }
        public required string TransactionType { get; init; }
        public bool Void { get; init; }
        public bool VoidAuth { get; init; }
        public bool VoidCapture { get; init; }
        public bool VoidReturn { get; init; }
        public bool VoidSale { get; init; }
        public bool VoidTransaction { get; init; }
    }
}
