using Projet.Datas.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Projet.Business;

namespace Projet.SaveTransactions
{
    public class Transaction
    {
        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; init; }

        [JsonPropertyName("amount")]
        public double Amount { get; init; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(TransactionTypeConverter))]
        public EnumTransactionType TransactionType { get; init; }

        [JsonPropertyName("date")]
        public DateTime TransactionDate { get; init; }

        [JsonPropertyName("currency")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumCurrency Currency { get; init; }

        [JsonPropertyName("exchangeRate")]
        public double ExchangeRate { get; init; }
    }
}
