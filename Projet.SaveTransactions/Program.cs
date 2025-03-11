using Projet.Business;
using Projet.Business.Services;
using Projet.Datas.Repositories;
using Projet.Luhn;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
    private static TransactionService _transactionService = new TransactionService();
    private static AnomalyService _anomalyService = new AnomalyService();
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Server Running...");
        try
        {
            string transJson = File.ReadAllText("./transactions.json");

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() } 
            };

            var transData = JsonSerializer.Deserialize<List<TransactionDto>>(transJson, options);
            foreach (TransactionDto transDto in transData)
            {
                if (Luhn.IsValid(transDto.CardNumber))
                {
                    if (await _transactionService.AddTransaction(transDto) > 0)
                    {
                        Console.WriteLine("Ajout en base réussi");
                    } else
                    {
                        Console.WriteLine("Echec de l'ajout en base");
                    }
                } else
                {
                    AnomalyDto anoDto = new AnomalyDto
                    {
                        CardNumber = transDto.CardNumber,
                        Amount = transDto.Amount,
                        Currency = transDto.Currency,
                        TransactionType = transDto.TransactionType,
                        TransactionDate = transDto.TransactionDate
                    };

                    if (await _anomalyService.AddTransaction(anoDto) > 0)
                    {
                        Console.WriteLine("Ajout en base réussi");
                    }
                    else
                    {
                        Console.WriteLine("Echec de l'ajout en base");
                    }

                }
            }
        } catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
    }
}