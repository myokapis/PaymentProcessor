﻿using Payment.Processor.Enums;
using Payment.Processor.Extensions;
using Payment.Processor.Services;
using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;
using Payment.Processor.Utilities;

namespace Payment.Processor.Builders
{
    public class CardContextBuilder : IBuilderAsync<CardContext>
    {
        protected IDecryptionService decryptionService;
        public CardContextBuilder(IDecryptionService decryptionService)
        {
            this.decryptionService = decryptionService;
        }

        public async Task<CardContext> BuildAsync(ITransactionModel transaction)
        {
            var encryptedCardData = transaction.Details.EncryptedCardData;
            // TODO: what should we do for unencrypted readers?
            var card = await decryptionService.DecryptCardData(encryptedCardData);
            var brand = CardBrand.Unknown.Parse(card?.Brand);
            var dataSource = DataSource.Unknown.Parse(card?.DataSource);
            var transactionMethod = TransactionMethod.Unknown.Parse(card?.TransactionMethod);
            var cardPresent = !transactionMethod.OneOf(TransactionMethod.Keyed, TransactionMethod.Token, TransactionMethod.Unknown);
            var processAs = ProcessAs(transaction, transactionMethod, cardPresent);
            var cardholderPresent = cardPresent || processAs == KeyedRate.Retail;

            return new CardContext()
            {
                Address = card?.Address,
                AvsPresent = AvsPresent(card),
                Brand = brand,
                CardholderPresent = cardholderPresent,
                CardPresent = cardPresent,
                CVV = card?.CVV,
                DataSource = dataSource,
                EMV = transactionMethod.OneOf(TransactionMethod.Dipped, TransactionMethod.QuickChip, TransactionMethod.Tapped),
                ExpirationMonth = card?.ExpirationMonth,
                ExpirationYear = card?.ExpirationYear,
                Keyed = transactionMethod == TransactionMethod.Keyed,
                Name = card?.Name,
                Number = card?.Number,
                ProcessAs = processAs,
                ServiceCode = card?.ServiceCode,
                Swiped = transactionMethod == TransactionMethod.Swiped,
                SwipedFallback = transactionMethod == TransactionMethod.SwipedFallback,
                TLV = card?.TLV,
                Track1 = card?.Track1,
                Track2 = card?.Track2,
                TransactionMethod = transactionMethod,
                ZipCode = card?.ZipCode
            };
        }

        private bool AvsPresent(Card? card)
        {
            if (card == null) return false;

            var workingAddress = card.Address?.Trim();

            if (!string.IsNullOrWhiteSpace(card.ZipCode)) return true;
            if (string.IsNullOrWhiteSpace(workingAddress)) return false;

            return Matchers.AddressMatcher().IsMatch(workingAddress);
        }

        private KeyedRate ProcessAs(ITransactionModel transaction, TransactionMethod transactionMethod, bool cardPresent)
        {
            if (cardPresent || transactionMethod != TransactionMethod.Keyed) return KeyedRate.Any;

            var platform = Platform.Unknown.Parse(transaction.Details?.Metadata?.Platform);
            var merchantInitiated = platform == Platform.ScheduledPayment;
            if (merchantInitiated) return KeyedRate.MOTO;

            var keyedRate = KeyedRate.Retail.Parse(transaction.Merchant.KeyedRate);
            return keyedRate == KeyedRate.Retail ? KeyedRate.Retail : KeyedRate.MOTO;
        }
    }
}
