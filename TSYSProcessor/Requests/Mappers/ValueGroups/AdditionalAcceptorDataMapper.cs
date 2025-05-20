using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;
using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class AdditionalAcceptorDataMapper : Mapper<AdditionalAcceptorData>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new AdditionalAcceptorData()
            {
                CustomerServicePhoneNumber = "8885551212",
                PhoneNumber = "8885551212",
                StreetAddress = "1444 First St."
            };
        }
    }
}
