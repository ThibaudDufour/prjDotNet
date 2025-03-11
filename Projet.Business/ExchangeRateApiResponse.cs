using System.Text.Json.Serialization;

namespace Projet.Business
{
    public class ExchangeRateApiResponse
    {
		[JsonPropertyName("base")]
		public string Base { get; set; }

		[JsonPropertyName("date")]
		public string Date { get; set; }

		[JsonPropertyName("rates")]
		public Dictionary<string, double> Rates { get; set; }
	}
}
