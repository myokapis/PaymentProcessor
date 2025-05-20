using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
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
