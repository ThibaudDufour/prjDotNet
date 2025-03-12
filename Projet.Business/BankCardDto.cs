using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projet.Business
{
    public class BankCardDto
    {
		[Required]
		[RegularExpression(@"^\d{16}$", ErrorMessage = "Le numéro de carte doit contenir exactement 16 chiffres.")]
		[JsonIgnore]
		public string CardNumber { get; init; }

		[Required]
		[JsonPropertyName("accountNumber")]
		public string AccountNumber { get; init; }

		[JsonPropertyName("maskedCardNumber")]
		public string MaskedCardNumber => $"**** **** **** {CardNumber[^4..]}";
	}
}
