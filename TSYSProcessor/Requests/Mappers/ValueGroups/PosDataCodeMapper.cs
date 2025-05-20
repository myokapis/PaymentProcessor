using TsysProcessor.Requests.Messages.ValueGroups;
using PaymentProcessor.Transaction;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;

namespace TsysProcessor.Requests.Mappers.ValueGroups
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
