using PaymentProcessor.Processor.ProcessStep;
using PaymentProcessor.Requests.Mappers;

namespace PaymentProcessor.Factories.Delegates
{
    public delegate IProcessStep ProcessStepFactory(Type type);
    public delegate IMapper MapperFactory(Type type);
}

