using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class DeveloperInformationMapper : Mapper<DeveloperInformation>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new DeveloperInformation()
            {
                ApplicationId = "APP1",
                DeveloperId = "Dev1",
                GatewayId = "Gateway1"
            };
        }
    }
}
