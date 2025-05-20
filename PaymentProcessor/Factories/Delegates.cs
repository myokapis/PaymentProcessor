using PaymentProcessor.Mappers;
using PaymentProcessor.Processor.ProcessStep;

namespace PaymentProcessor.Factories.Delegates
{
    public delegate IProcessStep ProcessStepFactory(Type type);
    public delegate IMapper MapperFactory(Type type);
}

