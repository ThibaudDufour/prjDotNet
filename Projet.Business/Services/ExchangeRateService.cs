using System.Text.Json;

namespace Projet.Business.Services
{
    public class ExchangeRateService
    {
        private readonly HttpClient _httpClient;
		private readonly string _baseUrl = "https://api.exchangerate-api.com/v4/latest/";

		public ExchangeRateService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<Dictionary<string, double>> GetExchangeRate(string currency = "EUR")
		{
			var response = await _httpClient.GetAsync($"{_baseUrl}{currency}");
			response.EnsureSuccessStatusCode();

			if (response.IsSuccessStatusCode)
			{
				var content = response.Content.ReadAsStringAsync().Result;
				var obj = JsonSerializer.Deserialize<ExchangeRateApiResponse>(content);

				return obj?.Rates ?? new Dictionary<string, double>();
			}
			else
			{
				throw new HttpRequestException("Error while fetching exchange rates");
			}
		}
	}
}
