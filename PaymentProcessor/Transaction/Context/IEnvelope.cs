﻿using PaymentProcessor.Messages;

namespace PaymentProcessor.Transaction.Context
{
    public interface IEnvelope<T> : IEnvelope, IAccessibleMessage<T>
    { }

    public interface IEnvelope
    {
        // TODO: add any envelope-specific behaviors
    }
}
