using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Serializers;
using TsysProcessor.Requests.Mappers.ValueGroups;
using TsysProcessor.Requests.Messages;
using TsysProcessor.Requests.Messages.Groups;
using PaymentProcessor.Transaction;
using System.Text;
using TsysProcessor.Requests.Mappers.Groups;
using PaymentProcessor.Mappers;
using PaymentProcessor.Messages;

namespace TsysProcessor.Requests.Mappers
{
    public class SaleMapper : ParentMapper<SaleMessage>
    {
        public SaleMapper(MapperFactory mapperFactory, IMessageSerializer messageSerializer) : base(mapperFactory, messageSerializer)
        {}

        public override IAccessibleMessage Map(Body transaction)
        {
            var builder = new StringBuilder();

            return new SaleMessage()
            {
                AccountDataSource = "XXX",
                AcquirerBin = 0,
                CardAcceptorData = MapValueGroup<CardAcceptorDataMapper>(transaction, builder),
                CardholderIdentificationData = "XXX",
                CityCode = "86753",
                CustomerDataField = "XXX",
                IndustryCode = IndustryCode(transaction),
                MarketSpecificDataIndicator = "XXX",
                ReversalCancelDataI = "XXX",
                ReversalIncrementalTransactionId = "XXX",
                TransactionCode = "XXX",
                Group3 = (Group3)MapGroup<Group3Mapper>(transaction)
            };
        }

        private string IndustryCode(Body transaction)
        {
            return transaction.Merchant.Industry switch
            {
                "RETAIL" => "R",
                "MOTO" => "D",
                _ => "",
            };
        }


    }
}
