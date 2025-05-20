using PaymentProcessor.Requests.Mappers.ValueGroups;
using PaymentProcessor.Requests.Messages;
using System.Text;
using PaymentProcessor.Requests.Messages.Groups;
using PaymentProcessor.Transaction;
using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Serializers;

namespace PaymentProcessor.Requests.Mappers.Groups
{
    public class Group3Mapper : ParentMapper<Group3>
    {
        public Group3Mapper(MapperFactory mapperFactory, IMessageSerializer messageSerializer) : base(mapperFactory, messageSerializer)
        { }

        public override IAccessibleMessage Map(Body transaction)
        {
            var builder = new StringBuilder();

            return new Group3()
            {
                AdditionalAcceptorData = MapValueGroup<AdditionalAcceptorDataMapper>(transaction, builder),
                AdditionalAmounts = MapValueGroup<AdditionalAmountsMapper>(transaction, builder),
                CardProductCode = MapValueGroup<CardProductCodeMapper>(transaction, builder),
                ChipConditionCode = MapValueGroup<ChipConditionCodeMapper>(transaction, builder),
                CitMitIndicator = MapValueGroup<CitMitIndicatorMapper>(transaction, builder),
                CommercialCardRequestIndicator = MapValueGroup<CommercialCardRequestIndicatorMapper>(transaction, builder),
                DeveloperInformation = MapValueGroup<DeveloperInformationMapper>(transaction, builder),
                ExtendedPosData = MapValueGroup<ExtendedPosDataMapper>(transaction, builder),
                FraudEnhancedData = MapValueGroup<FraudEnhancedDataMapper>(transaction, builder),
                IntegratedChipCard = "ICC Data",
                AdditionalTransactionSpecificData = MapValueGroup<AdditionalTransactionSpecificDataMapper>(transaction, builder),
                MasterCardPaymentIndicators = MapValueGroup<MasterCardPaymentIndicatorsMapper>(transaction, builder),
                MCAuthenticationData = MapValueGroup<MCAuthenticationDataMapper>(transaction, builder),
                MCAuthIndicator = MapValueGroup<MCAuthIndicatorMapper>(transaction, builder),
                MessageReasonCode = "REASON",
                MotoEcommIndicator = MapValueGroup<MotoEcommIndicatorMapper>(transaction, builder),
                PartialAuthIndicator = MapValueGroup<PartialAuthIndicatorMapper>(transaction, builder),
                PosDataCode = MapValueGroup<PosDataCodeMapper>(transaction, builder),
                PosEnvironmentIndicator = MapValueGroup<PosEnvironmentIndicatorMapper>(transaction, builder),
                SpendQualifiedIndicator = MapValueGroup<SpendQualifiedIndicatorMapper>(transaction, builder),
                TerminalAuthentication = "TERM AUTH",
                TransactionFeeAmount = MapValueGroup<TransactionFeeAmountMapper>(transaction, builder),
                TransactionIntegrityClass = MapValueGroup<TransactionIntegrityClassMapper>(transaction, builder)
            };
        }
    }
}
