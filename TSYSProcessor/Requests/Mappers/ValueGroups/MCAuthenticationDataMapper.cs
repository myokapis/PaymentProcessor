using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class MCAuthenticationDataMapper : Mapper<MCAuthenticationData>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new MCAuthenticationData();
        }
    }
}
