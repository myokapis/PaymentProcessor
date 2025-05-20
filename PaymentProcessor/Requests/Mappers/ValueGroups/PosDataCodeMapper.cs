using PaymentProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Requests.Messages;
using PaymentProcessor.Transaction;

namespace PaymentProcessor.Requests.Mappers.ValueGroups
{
    public class PosDataCodeMapper : Mapper<PosDataCode>
    {
        public override IAccessibleMessage Map(Body transaction)
        {
            return new PosDataCode()
            {
                CardholderAuthenticationEntity = '2',
                CardholderAuthenticationMethod = '3',
                CardholderPresentData = '4',
                CardInputMode = '5',
                CardPresentData = '6'
            };
        }
    }
}
