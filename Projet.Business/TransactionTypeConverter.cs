using Microsoft.Extensions.Primitives;
using Projet.Datas.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet.Business
{
    public class TransactionTypeConverter : JsonConverter<EnumTransactionType>
    {
        public override EnumTransactionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string stringValue = reader.GetString();
            EnumTransactionType enumValue;

            switch (stringValue)
            {
                case "ATM":
                    enumValue = EnumTransactionType.CashWithdrawal;
                    break;
                case "POS":
                    enumValue = EnumTransactionType.CardPayment;
                    break;
                case "CASH DEP":
                    enumValue = EnumTransactionType.CashDeposit;
                    break;
                default:
                    throw new JsonException($"Valeur {stringValue} non reconnue");
            }

            return enumValue;
        }

        public override void Write(Utf8JsonWriter writer, EnumTransactionType enumValue, JsonSerializerOptions options)
        {
            switch (enumValue)
            {
                case EnumTransactionType.CashWithdrawal:
                    writer.WriteStringValue("ATM");
                    break;
                case EnumTransactionType.CardPayment:
                    writer.WriteStringValue("POS");
                    break;
                case EnumTransactionType.CashDeposit:
                    writer.WriteStringValue("CASH DEP");
                    break;
            }
        }
    }
}
