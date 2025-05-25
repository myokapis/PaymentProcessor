<<<<<<< HEAD
﻿using PaymentProcessor.Transaction.Model;
=======
﻿using PaymentProcessor.Transaction;
>>>>>>> 239662c (refactored generics)

namespace PaymentProcessor.Builders
{
    public interface IBuilder<T>
    {
<<<<<<< HEAD
        T Build(ITransactionModel transaction);
=======
        T Build();
>>>>>>> 239662c (refactored generics)
    }
}
