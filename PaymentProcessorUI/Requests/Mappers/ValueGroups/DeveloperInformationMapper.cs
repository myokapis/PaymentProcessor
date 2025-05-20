using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
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
