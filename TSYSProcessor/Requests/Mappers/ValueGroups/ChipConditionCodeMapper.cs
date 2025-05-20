using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;
using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class ChipConditionCodeMapper : Mapper<ChipConditionCode>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new ChipConditionCode();
        }
    }
}
